using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class CertificationDetailsDto :BaseDto
	{
		public string? CertificationNumber { get; set; }
		public DateTime CompletionDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string? Attachment { get; set; }

		public int ResourceInformationId { get; set; }
	}
}
