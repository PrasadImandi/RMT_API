using AutoMapper;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ProjectsService(IGenericRepository<Project> _repository, IMapper _mapper) : IProjectsService
	{
		public async Task AddProjectAsync(ProjectDto project)
		{
			await _repository.AddAsync(_mapper.Map<Project>(project));
		}

		public async Task DeleteProjectAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(string searchText, int pageNumber = 0, int pageSize = 10)
		{
			var response = await _repository.GetAllAsync(query => query.Include(p => p.PM)
																				.Include(p => p.Client)
																				.Include(p => p.RM)
																				.Include(p => p.Segment)
																				.Include(p => p.DeleiveryMotion)
																				.Include(p => p.SupportType)
																				.Where(p => p.Name!.Contains(searchText))
																				.Skip(pageNumber * pageSize)
																				.Take(pageSize));

			var activeProjects = _mapper.Map<IEnumerable<ProjectDto>>(response);

			return activeProjects;
		}

		public async Task<ProjectDto> GetProjectByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);

			return _mapper.Map<ProjectDto>(response);
		}

		public async Task UpdateProjectAsync(ProjectDto project)
		{
			await _repository.UpdateAsync(_mapper.Map<Project>(project));
		}

		public async Task ChangeStatusProjectAsync(ProjectDto project)
		{
			await _repository.ChangeStatusAsync(project.ID, project.IsActive);
		}

		public async Task<IEnumerable<ProjectDto>> GetProjectByClientIdAsync(int clientId)
		{
			var response = await _repository.FindAsync(p => p.ClientID == clientId);

			return _mapper.Map<IEnumerable<ProjectDto>>(response);
		}
	}
}
