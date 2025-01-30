using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class AcademicDetails :  BaseModel
	{
		public DateTime CompletionDate { get; set; }
		public decimal ResultPercentage { get; set; }
		public string? Attachment { get; set; }
		public int ResourceInformationId { get; set; }
	}
}
