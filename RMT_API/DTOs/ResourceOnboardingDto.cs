using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ResourceOnboardingDto : BaseDto
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
