using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class DomainRoleRepository(ApplicationDBContext _context) : IDomainRoleRepository
	{
		public async Task<IEnumerable<DomainRoleMaster>> GetDomainRolesByDomainIdAsync(int domainId)
		{
			var domainRoles = await _context.DomainRoleMaster
				.Include(m => m.Domain)
			.Where(m => m.DomainID == domainId)
			.ToListAsync();

			return domainRoles!;
		}
	}
}
