using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IDomainRoleRepository
	{
		Task<IEnumerable<DomainRoleMaster>> GetDomainRolesByDomainIdAsync(int domainId);
	}
}
