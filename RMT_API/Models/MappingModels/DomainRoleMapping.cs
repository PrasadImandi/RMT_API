
using RMT_API.Models.BaseModels;

namespace RMT_API.Models.MappingModels
{
	public class DomainRoleMapping : ResourceIdentifier
	{
		public int DomainID { get; set; }
		public int RoleID { get; set; }
	}
}
