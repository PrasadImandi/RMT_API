using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

namespace RMT_API.Models
{
	public class JoiningDocuments :ResourceIdentifier
	{
		public string? AadharCard { get; set; }
		public string? AppraisalLetter { get; set; }
		public string? DrivingLicense { get; set; }
		public string? JoiningLetter { get; set; }
		public string? OfferLetter { get; set; }
		public string? PanCard { get; set; }
		public string? Passport { get; set; }

		public int? DocumentsID { get; set; }
		[JsonIgnore]
		public virtual Documents? Documents { get; set; }
	}
}
