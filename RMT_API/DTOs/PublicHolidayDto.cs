namespace RMT_API.DTOs
{
	public class PublicHolidayDto
	{
		public int PHID { get; set; }
		public string? PHName { get; set; }
		public string? PHDescription{get;set;}
		public bool? IsPublic{get;set; }
		public DateTime PHDate { get; set; }
		public DateTime PHYear { get; set; }
	}
}
