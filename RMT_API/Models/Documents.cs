using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Documents : BaseModel
	{
		public int ResourceInformationId { get; set; }
		public List<BGVDocuments> BGV { get; set; } = new();
		public List<JoiningDocuments> Joining { get; set; } = new();
	}
}
