using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class ResourceOnboarding
	{
		[Key]
		public int OnboardingID { get; set; }
		public int ResourceID { get; set; }
		public DateTime OnboardingDate { get; set; }
		public int HandledByID { get; set; }
		public string? DocumentName { get; set; }
		public string? DocumentPath { get; set; }
		public string? FileType { get; set; }
		public int FileSize { get; set; }
		public string? Notes { get; set; }
		public string? Status { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
