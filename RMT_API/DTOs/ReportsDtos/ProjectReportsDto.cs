namespace RMT_API.DTOs.ReportsDtos
{
	public class ProjectReportsDto
	{
		public string? ProjectName { get; set; }
		public string? ProjectCode { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string? ClientName { get; set; }
		public string? PMName { get; set; }
		public string? Manager { get; set; }
		public string? RMName { get; set; }
		public string? DomainName { get; set; }
		public string? DomainRoleName { get; set; }
		public string? DomainLevelName { get; set; }
		public string? RegionName { get; set; }
		public string? LocationName { get; set; }
		//public string? DeliveryMotionName { get; set; }
		//public string? SegmentName { get; set; }
		//public string? SupportTypeName { get; set; }
		public string? ProjectStatus { get; set; }
		public int? TotalSupplier { get; set; }
		public int? TotalBaseLine { get; set; }
	}
}
