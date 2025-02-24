
using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

namespace RMT_API.Models.MappingModels
{
	public class DomainRoleMapping : ResourceIdentifier
	{
		public int DomainID { get; set; }
		public int RoleID { get; set; }

		[JsonIgnore]
		public virtual DomainRoleMaster? DomainRole { get; set; }
	}
}
