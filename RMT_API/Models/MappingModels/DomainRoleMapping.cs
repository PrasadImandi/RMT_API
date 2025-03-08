
using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

namespace RMT_API.Models.MappingModels
{
	public class DomainRoleMapping : ResourceIdentifier
	{
		public int DomainID { get; set; }
		public int RoleID { get; set; }

		//public string? DomainName { get; set; }
		//public string? RoleName { get; set; }

		[JsonIgnore]
		public virtual DomainRoleMaster? DomainRole { get; set; }
		[JsonIgnore]
		public virtual DomainMaster? Domain { get; set; }
	}
}
