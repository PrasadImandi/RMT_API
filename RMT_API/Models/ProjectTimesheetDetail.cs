using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ProjectTimesheetDetail : ResourceIdentifier
	{
		public int ProjectID { get; set; }
		public int? TimesheetID { get; set; }
		public IEnumerable<TimesheetDetail>? TimesheetDetails { get; set; }
	}
}
