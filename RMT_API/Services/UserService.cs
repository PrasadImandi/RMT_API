using AutoMapper;
using RMT_API.DTOs;
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

		public async Task<IEnumerable<UsersDto>> GetAllUsersAsync()
		{
			var response = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<UsersDto>>(response);
		}

		public async Task<IEnumerable<UsersDto>> GetUsersByRoleIdAsync(int roleId)
		{
			var response = await userRepository.GetUsersByRoleIdAsync(roleId);
			return _mapper.Map<IEnumerable<UsersDto>>(response);
		}

		public async Task<UsersDto> GetUserByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<UsersDto>(response);
		}

		public async Task UpdateUserAsync(UsersDto user)
		{
			await _repository.UpdateAsync(_mapper.Map<Users>(user));
		}

		public async Task ChangeStatusUserAsync(UsersDto user)
		{
			await _repository.ChangeStatusAsync(user.ID, user.IsActive);
		}

		public async Task<UsersDto> GetUserByNameAsync(string name)
		{
			var response = await userRepository.GetUserByNameAsync(name);
			return _mapper.Map<UsersDto>(response);
		}

		public async Task<IEnumerable<UsersDto>> GetAllUsersWithChildAsync()
		{
			var response = await _repository.GetAllWithChildrenAsync(p => p.AccessType);

			return _mapper.Map<IEnumerable<UsersDto>>(response);
		}
	}

}
