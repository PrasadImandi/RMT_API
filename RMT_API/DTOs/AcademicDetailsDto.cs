using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class AcademicDetailsDto : BaseDto
	{
		public DateTime CompletionDate { get; set; }
		public decimal ResultPercentage { get; set; }
		public string? Attachment { get; set; }
		public int ResourceInformationId { get; set; }
	}
}
