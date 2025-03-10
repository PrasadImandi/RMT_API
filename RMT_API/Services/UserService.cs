using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class UsersService(IGenericRepository<Users> repository,
		IUserRepository userRepository, IMapper mapper) : IUsersService
	{
		private readonly IGenericRepository<Users> _repository = repository;
		private readonly IMapper _mapper = mapper;

		public async Task AddUserAsync(UsersDto user)
		{
			await _repository.AddAsync(_mapper.Map<Users>(user));
		}

		public async Task DeleteUserAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<UserDto>> GetAllUsersAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await _repository.GetAllAsync(query => query.Where(p => p.FirstName!.Contains(searchText) || p.LastName!.Contains(searchText))
																	  .Skip(pageNumber * pageSize)
																	  .Take(pageSize));
			return _mapper.Map<IEnumerable<UserDto>>(response);
		}

		public async Task<IEnumerable<UserDto>> GetUsersByRoleIdAsync(int roleId, string searchText, int pageNumber, int pageSize)
		{
			var response = await userRepository.GetUsersByRoleIdAsync(roleId);
			return _mapper.Map<IEnumerable<UserDto>>(response);
		}

		public async Task<UserDto> GetUserByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<UserDto>(response);
		}

		public async Task<UsersDto> GetUserWithPasswordByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsNoTrackingAsync(id);
			return _mapper.Map<UsersDto>(response);
		}

		public async Task UpdateUserAsync(UserDto user)
		{
			var updateuser = await GetUserWithPasswordByIdAsync(user.ID);

			if (updateuser != null)
			{
				updateuser.FirstName = user.FirstName;
				updateuser.LastName = user.LastName;
				updateuser.Email = user.Email;
				updateuser.UserName = user.UserName;
				updateuser.RoleID = user.RoleID;
				updateuser.IsActive = user.IsActive;

				await _repository.UpdateAsync(_mapper.Map<Users>(updateuser));
			}
		}

		public async Task ChangeStatusUserAsync(ResourceIdentifierDto user)
		{
			await _repository.ChangeStatusAsync(user.ID, user.IsActive);
		}

		public async Task<UsersDto> GetUserByNameAsync(string name)
		{
			var response = await userRepository.GetUserByNameAsync(name);
			return _mapper.Map<UsersDto>(response);
		}

		public async Task<IEnumerable<UserDto>> GetAllUsersWithChildAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await _repository.GetAllAsync(query => query.Include(x => x.AccessType));

			return _mapper.Map<IEnumerable<UserDto>>(response);
		}

		public async Task ChangePasswordAsync(string password, string username)
		{
			await userRepository.ChangePasswordAsync(password, username);
		}

	}

}
