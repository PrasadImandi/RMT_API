using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Project : ResourceIdentifier
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

		//public string? PMName { get; set; }
		//public string? RMName { get; set; }
		//public string? DeleiveryMotion { get; set; }
		//public string? Segment { get; set; }
		//public string? SupportType { get; set; }
	}
}
