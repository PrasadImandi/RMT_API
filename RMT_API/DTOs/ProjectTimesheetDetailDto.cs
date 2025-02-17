using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ProjectTimesheetDetailDto : ResourceIdentifierDto
	{
		public int ProjectID { get; set; }
		public int? TimesheetID { get; set; }
		public List<TimesheetDetailDto> TimesheetDetails { get; set; }
	}
}
