namespace RMT_API.DTOs
{
	public class ResourceDeploymentDto
	{
		public int DeploymentID { get; set; }
		public int ResourceID { get; set; }
		public int ProjectID { get; set; }
		public string? Role { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Status { get; set; }
		public decimal AllocationPercent { get; set; }
	}
}
