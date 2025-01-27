using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Leave
	{
		[Key]
		public int LeaveID { get; set; }
		public int ResourceID { get; set; }
		public int? LeaveType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Status { get; set; }
		public int ApproverID { get; set; }
		public DateTime Created_Date { get; set; }
		public int Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
