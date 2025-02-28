using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Timesheet : ResourceIdentifier
	{
		public int ResourceID { get; set; }
		public int PMID { get; set; }
		public int RMID { get; set; }
		public int TotalHours { get; set; }
		public int WorkedHours { get; set; }
		public DateTime WeekStartDate { get; set; }
		public DateTime WeekEndDate { get; set; }
		public string? Status { get; set; }
		public string? TimesheetCode { get; set; }
		public string? Notes { get; set; }
		public bool? IsNotified { get; set; }
		public bool? IsSubmit { get; set; }

		public string? PMRemarks { get; set; }
		public int? ApprovedBy { get; set; }
		public DateTime? ApprovalDate { get; set; }

		public IEnumerable<ProjectTimesheetDetail>? ProjectTimesheetDetails { get; set; }
		public Resource? Resource { get; set; }
	}
}
