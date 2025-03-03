using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class LeaveDto : ResourceIdentifierDto
	{
		public int ResourceID { get; set; }
		public int? LeaveType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Status { get; set; }
		public int ApproverID { get; set; }
		public string? Remarks { get; set; }
		public DateTime? ApprovedDate { get; set; }
	}
}
