using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class ResourceOffboarding
	{
		[Key]
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
		public string? Status { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
