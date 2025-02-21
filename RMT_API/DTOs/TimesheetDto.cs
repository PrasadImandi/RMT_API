using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class TimesheetDto :ResourceIdentifierDto
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
		public bool? IsNotified { get; set; }
		public bool? IsSubmit { get; set; }
		public List<ProjectTimesheetDetailDto>? ProjectTimesheetDetails { get; set; }
	}
}
