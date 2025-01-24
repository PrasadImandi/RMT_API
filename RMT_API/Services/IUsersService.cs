using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IUsersService
	{
		Task<IEnumerable<UsersDto>> GetAllUsersAsync();
		Task<IEnumerable<UsersDto>> GetUsersByRoleIdAsync(int roleId);
		Task<UsersDto> GetUserByIdAsync(int id);
		Task<UsersDto> GetUserByNameAsync(string name);
		Task AddUserAsync(UsersDto user);
		Task UpdateUserAsync(UsersDto user);
		Task DeleteUserAsync(int id);
		Task ChangeStatusUserAsync(UsersDto user);
	}
}
