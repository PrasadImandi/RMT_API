using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class JoiningDocuments
	{
		[Key]
		public int Id { get; set; }
		public string? AadharCard { get; set; }
		public string? appraisalLetter { get; set; }
		public string? drivingLicense { get; set; }
		public string? joiningLetter { get; set; }
		public string? offerLetter { get; set; }
		public string? panCard { get; set; }
		public string? passport { get; set; }
	}
}
