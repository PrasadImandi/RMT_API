using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class CertificationDetails
	{
		[Key]
		public int CertificationID { get; set; }
		public string? CertificationName { get; set; }
		public string? CertificationNumber { get; set; }
		public int YearOfCompleted { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string? Attachment { get; set; }

		public int ResourceInformationId { get; set; }
	}
}
