namespace RMT_API.DTOs
{
	public class ResourceLifeCycleDto
	{
		public int LifecycleID { get; set; }
		public int ResourceID { get; set; }
		public string? LifecycleType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string? Status { get; set; }
		public string? Notes { get; set; }
		public int HandledByID { get; set; }
	}
}
