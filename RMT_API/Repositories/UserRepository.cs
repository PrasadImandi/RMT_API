using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class UserRepository(ApplicationDBContext _context) : IUserRepository
	{
		public async Task<IEnumerable<Users>> GetUsersByRoleIdAsync(int id)
		{
			return await _context.Users.Where(x => x.AccessTypeID == id).ToListAsync();
		}

		public async Task<Users> GetUserByNameAsync(string name)
		{
			var response = await _context.Users!.FirstOrDefaultAsync(x => x.Name == name);
			return response!;
		}
	}

}
