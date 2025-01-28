using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class JoiningDocuments
	{
		[Key]
		public int JoiningDocumentId { get; set; }
		public string? AadharCard { get; set; }
		public string? appraisalLetter { get; set; }
		public string? drivingLicense { get; set; }
		public string? joiningLetter { get; set; }
		public string? offerLetter { get; set; }
		public string? panCard { get; set; }
		public string? passport { get; set; }
		public DateTime? Created_Date { get; set; }
		public int Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
