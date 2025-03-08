using RMT_API.Models.BaseModels;
using RMT_API.Models.MappingModels;

namespace RMT_API.Models
{
	public class DomainMaster : BaseModel
	{
		public ICollection<DomainRoleMapping>? DomainRoleMappings { get; set; }
	}
}
