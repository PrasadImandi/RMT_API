using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class AcademicDetails
	{
		[Key]
		public int AcademicID { get; set; }
		public string? AcademicName { get; set; }
		public int YearOfCompleted { get; set; }
		public decimal ResultPercentage { get; set; }
		public string Attachment { get; set; }

		public int ResourceInformationId { get; set; }
	}
}
