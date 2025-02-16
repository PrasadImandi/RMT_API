using RMT_API.DTOs;
using RMT_API.Models;

namespace RMT_API.Services
{
	public interface ITimesheetsService
	{
		Task<IEnumerable<TimesheetDto>> GetAllTimesheetsAsync();
		Task<TimesheetDto> GetTimesheetByIdAsync(int id);
		Task AddTimesheetAsync(TimesheetDto timesheet);
		Task UpdateTimesheetAsync(TimesheetDto timesheet);
		Task DeleteTimesheetAsync(int id);
		Task ChangeStatusTimesheetAsync(TimesheetDto timesheet);
		Task<Timesheet> GetWeekTimesheetByStartDate(int resourceId, DateTime startOfWeek);



		//Task<Timesheet> GetPreviousWeekTimesheet(int resourceId, DateTime startOfWeek);
		//Task<Timesheet> GetCurrentWeekTimesheet(int resourceId);
	}
}
