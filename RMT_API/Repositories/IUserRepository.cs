using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IUserRepository
	{
		Task ChangeStatusUser(Users user);
		Task<IEnumerable<Users>> GetMangersAsync();
	}
}
