using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

namespace RMT_API.Models
{
	public class AcademicDetails :  BaseModel
	{
		public DateTime CompletionDate { get; set; }
		public decimal ResultPercentage { get; set; }
		public string? Attachment { get; set; }

		public int ResourceInformationID { get; set; }
		[JsonIgnore]
		public virtual ResourceInformation? ResourceInformation { get; set; }
	}
}
