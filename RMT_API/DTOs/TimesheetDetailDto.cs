using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class TimesheetDetailDto : ResourceIdentifierDto
	{
		public int TimesheetId { get; set; }
		public DateTime WorkDate { get; set; }
		public int HoursWorked { get; set; }
		//public string? WorkDescription { get; set; }
	}
}
