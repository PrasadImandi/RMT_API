using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;

namespace RMT_API.DTOs
{
	public class TimesheetDto :ResourceIdentifierDto
	{
		public int ResourceID { get; set; }
		public int TotalHours { get; set; }
		public int WorkedHours { get; set; }
		public DateTime WeekStartDate { get; set; }
		public DateTime WeekEndDate { get; set; }
		public string Status { get; set; }
		//public string Notes { get; set; }
		public List<ProjectTimesheetDetailDto> ProjectTimesheetDetails { get; set; }
	}
}
