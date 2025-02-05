using RMT_API.Models.BaseModels;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace RMT_API.Models
{
	public class BGVDocuments :BaseModel
	{
		public string? Description{ get; set; }
		public string[]? Attachments{ get; set; }

		public int? DocumentsID { get; set; }
		[JsonIgnore]
		public virtual Documents? Documents { get; set; }
	}
}
