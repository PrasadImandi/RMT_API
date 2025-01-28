namespace RMT_API.DTOs
{
	public class ProjectDto
	{
		public int ProjectID { get; set; }
		public string? ProjectName { get; set; }
		public int ClientID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Status { get; set; }
	}
}
