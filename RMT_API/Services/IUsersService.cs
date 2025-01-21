using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IUsersService
	{
		Task<IEnumerable<UsersDto>> GetAllUsersAsync();
		Task<IEnumerable<UsersDto>> GetMangersAsync();
		Task<UsersDto> GetUserByIdAsync(int id);
		Task AddUserAsync(UsersDto user);
		Task UpdateUserAsync(UsersDto user);
		Task DeleteUserAsync(int id);
		Task ChangeStatusUserAsync(UsersDto user);
	}
}
