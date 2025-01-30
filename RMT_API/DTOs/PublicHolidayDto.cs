using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class PublicHolidayDto :BaseDto
	{
		public bool? IsPublic{get;set; }
		public DateTime PHDate { get; set; }
		public DateTime PHYear { get; set; }
	}
}
