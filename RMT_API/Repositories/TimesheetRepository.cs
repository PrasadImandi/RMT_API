using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class TimesheetRepository(ApplicationDBContext _context) : ITimesheetRepository
	{

		public async Task<Timesheet> GetNextWeekTimesheet(int resourceId, DateTime startOfWeek)
		{
			// Calculate the start and end dates for the next week
			DateTime startOfNextWeek = GetStartOfWeek(startOfWeek);
			DateTime endOfNextWeek = startOfNextWeek.AddDays(6);

			// Query for the timesheet for the next week
			var weekTimesheet = await GetTimesheetAsync( resourceId, startOfNextWeek, endOfNextWeek);
			
			if (weekTimesheet == null)
			{
				int totalHours =await CalculateTotalTimesheetHours(startOfNextWeek,endOfNextWeek);

				weekTimesheet = new()
				{
					WeekStartDate = startOfNextWeek,
					WeekEndDate = endOfNextWeek,
					IsActive = true,
					Status ="pending",
					ResourceID = resourceId,
					TotalHours = totalHours
				};

				await _context.AddAsync(weekTimesheet);
				await _context.SaveChangesAsync();

				weekTimesheet = await GetTimesheetAsync(resourceId, startOfNextWeek, endOfNextWeek);
			}

			return weekTimesheet;
		}

		private async Task<int> CalculateTotalTimesheetHours(DateTime startOfWeek, DateTime endOfWeek)
		{
			var holidaysInWeek = await _context.PublicHolidaysMaster
						.Where(h => h.PHDate >= startOfWeek && h.PHDate <= endOfWeek && (h.IsActive ?? false))
						.ToListAsync();

			return 40 - (holidaysInWeek.Count * 8);
		}


		private async Task<Timesheet> GetTimesheetAsync(int resourceId, DateTime startOfWeek, DateTime endOfWeek)
		{
			var _timesheet = await _context.Timesheet
				.Where(t => t.WeekStartDate >= startOfWeek && t.WeekEndDate <= endOfWeek && (t.IsActive ?? false) && t.ResourceID == resourceId)
				.FirstOrDefaultAsync();

			return _timesheet;

		}

		private DateTime GetStartOfWeek(DateTime date)
		{
			// Assuming the week starts on Monday (you can change the logic for a different start day)
			int diff = date.DayOfWeek - DayOfWeek.Monday;
			if (diff < 0)
				diff += 7;

			return date.AddDays(-diff).Date;
		}
	}
}
