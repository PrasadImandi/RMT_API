using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;

namespace RMT_API.Services
{
	public interface IUsersService
	{
		Task<IEnumerable<UserDto>> GetAllUsersAsync(string searchText, int pageNumber, int pageSize);
		Task<IEnumerable<UserDto>> GetAllUsersWithChildAsync(string searchText, int pageNumber, int pageSize);
		Task<IEnumerable<UserDto>> GetUsersByRoleIdAsync(int roleId, string searchText, int pageNumber, int pageSize);
		Task<UserDto> GetUserByIdAsync(int id);
		Task<UsersDto> GetUserByNameAsync(string name);
		Task AddUserAsync(UsersDto user);
		Task UpdateUserAsync(UserDto user);
		Task DeleteUserAsync(int id);
		Task ChangeStatusUserAsync(ResourceIdentifierDto user);
		Task ChangePasswordAsync(string password, string username);
	}
}
