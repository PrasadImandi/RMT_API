using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Infrastructure.Enums;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ManagerService(IGenericRepository<Manager> repository, IManagerRepository managerRepository,IMapper mapper) : IManagerService
	{
		public async Task AddManagerAsync(ManagerDto accessType)
		{
			await repository.AddAsync(mapper.Map<Manager>(accessType));
		}

		public async Task ChangeStatusManagerAsync(ManagerDto accessType)
		{
			await repository.ChangeStatusAsync(accessType.ID, accessType.IsActive);
		}

		public async Task DeleteManagerAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task<ManagerDto> GetManagerByIdAsync(int id)
		{
			var response = await repository.GetByIdAsync(id);
			return mapper.Map<ManagerDto>(response);
		}

		public async Task<IEnumerable<ManagerDto>> GetAllManagersAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await repository.GetAllAsync(query => query.Where(p => p.FirstName!.Contains(searchText) || p.LastName!.Contains(searchText))
			.Skip(pageNumber * pageSize)
			.Take(pageSize));
			return mapper.Map<IEnumerable<ManagerDto>>(response);
		}

		public async Task UpdateManagerAsync(ManagerDto accessType)
		{
			await repository.UpdateAsync(mapper.Map<Manager>(accessType));
		}

		public async Task<IEnumerable<ManagerDto>> GetProjectManagersByProjectIdAsync(int projectId)
		{
			var response = await managerRepository.GetProjectManagersByProjectIdAsync(projectId);
			return mapper.Map<IEnumerable<ManagerDto>>(response);
		}

		public async Task<IEnumerable<ManagerDto>> GetReportingManagersByProjectIdAsync(int projectId)
		{
			var response = await managerRepository.GetReportingManagersByProjectIdAsync(projectId);
			return mapper.Map<IEnumerable<ManagerDto>>(response);
		}
	}
}
