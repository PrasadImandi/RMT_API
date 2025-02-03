using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Project : BaseModel
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

		public virtual Client? Client { get; set; }
		public virtual Manager? PM { get; set; }
		public virtual ReportingManager? RM { get; set; }
		public virtual DeliveryMotionMaster? DeleiveryMotion { get; set; } = null;
		public virtual SegmentMaster? Segment { get; set; }
		public virtual SupportTypeMaster? SupportType { get; set; }
	}
}
