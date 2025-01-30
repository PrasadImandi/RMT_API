using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class JoiningDocuments :ResourceIdentifier
	{
		public string? AadharCard { get; set; }
		public string? appraisalLetter { get; set; }
		public string? drivingLicense { get; set; }
		public string? joiningLetter { get; set; }
		public string? offerLetter { get; set; }
		public string? panCard { get; set; }
		public string? passport { get; set; }
	}
}
