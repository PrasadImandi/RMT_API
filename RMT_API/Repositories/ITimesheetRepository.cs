using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface ITimesheetRepository
	{
		Task<Timesheet> GetNextWeekTimesheet(int resourceId, DateTime startOfWeek);
		Task ApproveTimesheet(int id, string? status, string? remarks, DateTime? approvalDate, int? pmId);

	}
}
