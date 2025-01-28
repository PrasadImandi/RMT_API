using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class BGVDocuments
	{
		[Key]
		public int BGVDocumentID { get; set; }
		public string? BGVDocumentName { get; set; }
		public string? BGVDocumentDescription { get; set; }
		public string[]? Attachments{ get; set; }
	}
}
