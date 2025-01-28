using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class RolesService(IGenericRepository<Role> _repository,
		 IMapper _mapper) : IRolesService
	{
		public async Task AddRoleAsync(RoleDto role)
		{
			await _repository.AddAsync(_mapper.Map<Role>(role));
		}

		public async Task DeleteRoleAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
		{
			var response = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<RoleDto>>(response);
		}

		public async Task<RoleDto> GetRoleByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<RoleDto>(response);
		}

		public async Task UpdateRoleAsync(RoleDto role)
		{
			await _repository.UpdateAsync(_mapper.Map<Role>(role));
		}

		public async Task ChangeStatusRoleAsync(RoleDto role)
		{
			await _repository.ChangeStatusAsync(role.ID, role.IsActive);
		}
	}
}
