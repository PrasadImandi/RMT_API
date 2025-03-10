using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IProjectsService
	{
		Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(string searchText, int pageNumber = 0, int pageSize = 10);
		Task<ProjectDto> GetProjectByIdAsync(int id);
		Task<IEnumerable<ProjectDto>> GetProjectByClientIdAsync(int clientId);
		Task AddProjectAsync(ProjectDto project);
		Task UpdateProjectAsync(ProjectDto project);
		Task DeleteProjectAsync(int id);
		Task ChangeStatusProjectAsync(ProjectDto project);
	}
}
