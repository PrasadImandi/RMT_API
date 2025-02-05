using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

namespace RMT_API.Models
{
	public class CertificationDetails : BaseModel
	{
		public string? CertificationNumber { get; set; }
		public DateTime CompletionDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string? Attachment { get; set; }

		public int ResourceInformationID { get; set; }
		[JsonIgnore]
		public virtual ResourceInformation? ResourceInformation { get; set; }
	}
}
