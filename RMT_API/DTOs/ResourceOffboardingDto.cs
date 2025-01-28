namespace RMT_API.DTOs
{
	public class ResourceOffboardingDto
	{
		public int OffboardingID { get; set; }
		public int ResourceID { get; set; }
		public DateTime OffboardingDate { get; set; }
		public int HandledByID { get; set; }
		public string? ExitDocumentName { get; set; }
		public string? DocumentPath { get; set; }
		public string? FileType { get; set; }
		public int FileSize { get; set; }
		public string? ExitReason { get; set; }
		public string? Notes { get; set; }
	}
}
