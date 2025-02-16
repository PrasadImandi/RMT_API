using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface ITimesheetRepository
	{
		//Task<Timesheet> GetPreviousWeekTimesheet(int resourceId, DateTime startOfWeek);
		//Task<Timesheet> GetCurrentWeekTimesheet(int resourceId);
		Task<Timesheet> GetNextWeekTimesheet(int resourceId, DateTime startOfWeek);
	}
}
