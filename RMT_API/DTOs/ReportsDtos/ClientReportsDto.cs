namespace RMT_API.DTOs.ReportsDtos
{
	public class ClientReportsDto
	{
		public string? Project { get; set; }
		public string? Logo { get; set; }
		public string? PM { get; set; }
		public string? Manager { get; set; }
		public string? RM1 { get; set; }
		public string? Region { get; set; }
		public string? Location { get; set; }
		public DateTime? ProjectStartDate { get; set; }
		public DateTime? ProjectEndDate { get; set; }
		public string? LogoStatus { get; set; }
		public string? ProjectStatus { get; set; }
		public int? TotalSupplier { get; set; }
		public int? TotalBaseLine { get; set; }
	}
}
