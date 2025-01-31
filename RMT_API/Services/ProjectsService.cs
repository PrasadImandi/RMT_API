using AutoMapper;
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

		public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
		{
			var response = await  _repository.GetAllWithChildrenAsync(p => p.RM,
																	  p => p.PM,
																	  p => p.Segment,
																	  p => p.DeleiveryMotion,
																	  p => p.SupportType);

			var activeProjects = _mapper.Map<IEnumerable<ProjectDto>>(response.Where(p => p.IsActive == true));

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
	}
}
