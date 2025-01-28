using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<Users>> GetUsersByRoleIdAsync(int roleId);
		Task<Users> GetUserByNameAsync(string name);
	}
}
