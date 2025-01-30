using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class BGVDocuments :BaseModel
	{
		public string? Description{ get; set; }
		public string[]? Attachments{ get; set; }
	}
}
