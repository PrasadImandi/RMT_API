using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

namespace RMT_API.Models
{
	public class Documents : ResourceIdentifier
	{
		public int ResourceInformationID { get; set; }

		public virtual ICollection<BGVDocuments>? BGV { get; set; } = null;
		public virtual JoiningDocuments? Joining { get; set; } = null;

		[JsonIgnore]
		public virtual ResourceInformation? ResourceInformation { get; set; }

	}
}
