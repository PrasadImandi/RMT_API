using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class TimesheetRepository(ApplicationDBContext _context) : ITimesheetRepository
	{

		public async Task<Timesheet> GetNextWeekTimesheet(int resourceId, DateTime startOfWeek)
		{
			DateTime startOfNextWeek = GetStartOfWeek(startOfWeek);
			DateTime endOfNextWeek = startOfNextWeek.AddDays(6);

			List<DateTime> dates = GetDatesInRange(startOfNextWeek, endOfNextWeek);

			var weekTimesheet = await GetTimesheetAsync(resourceId, startOfNextWeek, endOfNextWeek);

			var holidaysInWeek = await _context.PublicHolidaysMaster
				.Where(h => h.PHDate >= startOfNextWeek && h.PHDate <= endOfNextWeek && (h.IsActive ?? false))
				.ToListAsync();

			var holidaySet = new HashSet<DateTime>(holidaysInWeek.Select(h => h.PHDate.Date));

			if (weekTimesheet == null)
			{
				int totalHours = 40 - (holidaysInWeek.Count * 8);

				weekTimesheet = new Timesheet
				{
					ID=0,
					WeekStartDate = startOfNextWeek,
					WeekEndDate = endOfNextWeek,
					IsActive = true,
					Status = "pending",
					ResourceID = resourceId,
					TotalHours = totalHours
				};

				await _context.AddAsync(weekTimesheet);
				await _context.SaveChangesAsync();

				var defaultDeployedProject = await _context.ResourceDeployments
					.Where(x => x.IsDefault && x.ResourceID == resourceId)
					.FirstOrDefaultAsync();

				if (defaultDeployedProject != null)
				{
					var projectTimesheetDetail = new ProjectTimesheetDetail
					{
						TimesheetID =weekTimesheet.ID,
						ProjectID = defaultDeployedProject.ProjectID,
						IsActive =true
					};

					await _context.ProjectTimesheetDetail.AddAsync(projectTimesheetDetail);
					await _context.SaveChangesAsync();

					var timesheetDetails = dates.Select(date => new TimesheetDetail
					{
						IsActive = true,
						HoursWorked = 0,
						TimesheetId = weekTimesheet.ID,
						ProjectTimesheetDetailID = projectTimesheetDetail.ID, 
						WorkDate = date,
						WorkDescription = string.Empty,
						IsHoliday = holidaySet.Contains(date.Date)
					}).ToList();

					await _context.TimesheetDetail.AddRangeAsync(timesheetDetails);
					await _context.SaveChangesAsync();

					weekTimesheet = await GetTimesheetAsync(resourceId, startOfNextWeek, endOfNextWeek);
				}
			}

			return weekTimesheet;
		}


		private List<DateTime> GetDatesInRange(DateTime startDate, DateTime endDate)
		{
			List<DateTime> dates = new List<DateTime>();
			for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
			{
				dates.Add(date);
			}
			return dates;
		}

		private async Task<Timesheet> GetTimesheetAsync(int resourceId, DateTime startOfWeek, DateTime endOfWeek)
		{
			var _timesheet = await _context.Timesheet
				.Include(x=>x.ProjectTimesheetDetails!)
				.ThenInclude(x => x.TimesheetDetails)
				.Where(t => t.WeekStartDate >= startOfWeek && t.WeekEndDate <= endOfWeek && (t.IsActive ?? false) && t.ResourceID == resourceId)
				.FirstOrDefaultAsync();

			return _timesheet!;

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
