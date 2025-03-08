using RMT_API.Models.BaseModels;
using RMT_API.Models.MappingModels;

namespace RMT_API.Models
{
	public class DomainRoleMaster : BaseModel
	{
		//public int? DomainID { get; set; }
		public ICollection<DomainRoleMapping>? DomainRoleMappings { get; set; }
	}
}
