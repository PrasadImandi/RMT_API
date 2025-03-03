using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ProjectBaseLineService(IGenericRepository<ProjectBaseLine> repository, IMapper mapper) : IProjectBaseLineService
	{
		public async Task AddProjectBaseLineAsync(ProjectBaseLineDto projectBaseLine)
		{
			await repository.AddAsync(mapper.Map<ProjectBaseLine>(projectBaseLine));
		}

		public async Task ChangeStatusProjectBaseLineAsync(ProjectBaseLineDto projectBaseLine)
		{
			await repository.ChangeStatusAsync(projectBaseLine.ID, projectBaseLine.IsActive);
		}

		public async Task DeleteProjectBaseLineAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ProjectBaseLineDto>> GetAllProjectBaseLinesAsync()
		{
			var response = await repository.GetAllWithChildrenAsync(query => query.Include(p => p.Client)
																				.Include(p => p.Project)
																				.Include(p => p.Domain)
																				.Include(p => p.DomainRole)
																				.Include(p => p.DomainLevel));
			return mapper.Map<IEnumerable<ProjectBaseLineDto>>(response);
		}

		public async Task<ProjectBaseLineDto> GetProjectBaseLineByIdAsync(int id)
		{
			var response = await repository.GetByIdAsync(id);
			return mapper.Map<ProjectBaseLineDto>(response);
		}

		public async Task UpdateProjectBaseLineAsync(ProjectBaseLineDto projectBaseLine)
		{
			await repository.UpdateAsync(mapper.Map<ProjectBaseLine>(projectBaseLine));
		}
	}
}
