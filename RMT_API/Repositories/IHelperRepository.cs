using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IHelperRepository
	{
		Task<IEnumerable<FormMaster>> GetLeftNavItemsByRoleIdAsync(int id);
	}
}
