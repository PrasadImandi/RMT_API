using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Leave : BaseModel
	{
		public int ResourceID { get; set; }
		public int? LeaveType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Status { get; set; }
		public int ApproverID { get; set; }
	}
}
