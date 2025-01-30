using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class BGVDocumentDto :BaseDto
	{
		public string? Description { get; set; }
		public string[]? Attachments { get; set; }
		public int? DocumentID { get; set; }
	}
}
