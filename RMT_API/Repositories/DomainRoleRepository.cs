using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class DomainRoleRepository(ApplicationDBContext _context) : IDomainRoleRepository
	{
		public async Task<IEnumerable<DomainRoleMaster>> GetDomainRolesByDomainIdAsync(int domainId)
		{
			var domainRoles = await _context.DomainRoleMappings
			.Where(mapping => mapping.DomainID == domainId)
			.Select(mapping => mapping.DomainRole)
			.ToListAsync();

			return domainRoles!;
		}
	}
}
