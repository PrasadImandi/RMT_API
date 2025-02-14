using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class TimesheetDetail : ResourceIdentifier
	{
		public int TimesheetId { get; set; }
		public DateTime WorkDate { get; set; }
		public int HoursWorked { get; set; }
		public string? WorkDescription { get; set; }
		public int ProjectTimesheetDetailID { get; set; }

	}
}
