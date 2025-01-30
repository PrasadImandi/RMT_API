using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IUsersService
	{
		Task<IEnumerable<UserDto>> GetAllUsersAsync();
		Task<IEnumerable<UserDto>> GetAllUsersWithChildAsync();
		Task<IEnumerable<UserDto>> GetUsersByRoleIdAsync(int roleId);
		Task<UserDto> GetUserByIdAsync(int id);
		Task<UsersDto> GetUserByNameAsync(string name);
		Task AddUserAsync(UsersDto user);
		Task UpdateUserAsync(UsersDto user);
		Task DeleteUserAsync(int id);
		Task ChangeStatusUserAsync(UsersDto user);
		Task ChangePasswordAsync(string password, string username);
	}
}
