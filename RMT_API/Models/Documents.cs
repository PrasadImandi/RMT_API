using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Documents : ResourceIdentifier
	{
		public int ResourceInformationId { get; set; }
		public List<BGVDocuments>? BGV { get; set; } = null;
		public JoiningDocuments? Joining { get; set; } = null;
	}
}
