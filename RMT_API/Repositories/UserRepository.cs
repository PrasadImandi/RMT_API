using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class UserRepository(IGenericRepository<Users> repository, ApplicationDBContext _context) : IUserRepository
	{
		private readonly IGenericRepository<Users> _repository = repository;

		public async Task ChangeStatusUser(Users user)
		{
			var existingUser = await _repository.GetByIdAsync(user.UserID, "UserID");

			if (existingUser != null)
			{
				existingUser.IsActive = user.IsActive;

				await _repository.UpdateAsync(existingUser);
			}
		}

		public async Task<IEnumerable<Users>> GetUsersByRoleIdAsync(int id)
		{
			return await _context.Users.Where(x => x.AccessTypeID == id).ToListAsync();
		}

		public async Task<Users> GetUserByNameAsync(string name)
		{
			var response = await _context.Users!.FirstOrDefaultAsync(x => x.FullName == name);
			return response!;
		}
	}

}
