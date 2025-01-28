
using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ResourceOnboarding :BaseModel
	{
		public int ResourceID { get; set; }
		public DateTime OnboardingDate { get; set; }
		public int HandledByID { get; set; }
		public string? DocumentName { get; set; }
		public string? DocumentPath { get; set; }
		public string? FileType { get; set; }
		public int FileSize { get; set; }
		public string? Notes { get; set; }
	}
}
