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
				var holidaysInWeek =await _context.PublicHolidaysMaster
						.Where(h => h.PHDate >= startOfNextWeek && h.PHDate <= endOfNextWeek && (h.IsActive??false))
						.ToListAsync();

				int totalHours = 40- (holidaysInWeek.Count * 8);

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


		public async Task<Timesheet> GetTimesheetAsync(int resourceId, DateTime startOfWeek, DateTime endOfWeek)
		{
			var _timesheet = await _context.Timesheet
				.Where(t => t.WeekStartDate >= startOfWeek && t.WeekEndDate <= endOfWeek && (t.IsActive ?? false) && t.ResourceID == resourceId)
				.FirstOrDefaultAsync();

			return _timesheet;

		}

		//public async Task<Timesheet> GetPreviousWeekTimesheet(int resourceId, DateTime startOfWeek)
		//{
		//	// Calculate the start and end dates for the previous week
		//	DateTime startOfPrevWeek = startOfWeek==DateTime.MinValue ? GetStartOfWeek(DateTime.Now).AddDays(-7) : GetStartOfWeek(startOfWeek).AddDays(-7);
		//	DateTime endOfPrevWeek = startOfPrevWeek.AddDays(6);

		//	// Query for the timesheet for the previous week
		//	var previousWeekTimesheet =await  _context.Timesheet
		//		.Where(t => t.WeekStartDate >= startOfPrevWeek && t.WeekEndDate <= endOfPrevWeek && (t.IsActive ?? false) && t.ResourceID == resourceId)
		//		.FirstOrDefaultAsync();

		//	return previousWeekTimesheet;
		//}

		//public async Task<Timesheet> GetCurrentWeekTimesheet(int resourceId)
		//{
		//	// Calculate the start and end dates for the current week (assuming weeks start on Monday)
		//	DateTime startOfWeek = GetStartOfWeek(DateTime.Now);
		//	DateTime endOfWeek = startOfWeek.AddDays(6);

		//	// Query for the timesheet for the current week
		//	var currentWeekTimesheet = await _context.Timesheet
		//								.Where(t => t.WeekStartDate >= startOfWeek && t.WeekEndDate <= endOfWeek && (t.IsActive ?? false) && t.ResourceID == resourceId)
		//								.FirstOrDefaultAsync();

		//	return currentWeekTimesheet ?? new();
		//}

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
