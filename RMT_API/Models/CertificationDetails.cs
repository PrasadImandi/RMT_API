using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class CertificationDetails : BaseModel
	{
		public string? CertificationNumber { get; set; }
		public int YearOfCompleted { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string? Attachment { get; set; }

		public int ResourceInformationId { get; set; }
	}
}
