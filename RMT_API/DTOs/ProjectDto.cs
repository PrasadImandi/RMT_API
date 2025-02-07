using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ProjectDto :BaseDto
	{
		public string? ProjectCode { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		public int? ClientID { get; set; }
		public int? PMID { get; set; }
		public int? RMID { get; set; }
		public int? DeleiveryMotionID { get; set; }
		public int? SegmentID { get; set; }
		public int? SupportTypeID { get; set; }

		public string? ClientName { get; set; }
		public string? PMName { get; set; }
		public string? RMName { get; set; }
		public string? DeleiveryMotionName { get; set; }
		public string? SegmentName { get; set; }
		public string? SupportTypeName { get; set; }
	}
}
