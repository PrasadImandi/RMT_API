using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

namespace RMT_API.Models
{
	public class ContactTypeMaster : BaseModel
	{
		[JsonIgnore]
		public virtual ICollection<ContactInformation>? ContactInformations { get; set; }
	}
}
