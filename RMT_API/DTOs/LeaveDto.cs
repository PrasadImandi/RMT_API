namespace RMT_API.DTOs
{
	public class LeaveDto
	{
		public int ID { get; set; }
		public int ResourceID { get; set; }
		public int? LeaveType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool? IsActive { get; set; }
		public int ApproverID { get; set; }
	}
}
