using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

namespace RMT_API.Models
{
	public class Timesheet : ResourceIdentifier
	{
		public int ResourceID { get; set; }
		public int TotalHours { get; set; }
		public int WorkedHours { get; set; }
		public DateTime WeekStartDate { get; set; }
		public DateTime WeekEndDate { get; set; }
		public string? Status { get; set; }
		public string? Notes { get; set; }
		public IEnumerable<ProjectTimesheetDetail> ProjectTimesheetDetails { get; set; }
	}
}
