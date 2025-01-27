using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ProjectRepository(IGenericRepository<Project> repository) : IProjectRepository
	{
		private readonly IGenericRepository<Project> _repository = repository;

		public async Task ChangeStatusProject(Project project)
		{
			var existingProject = await _repository.GetByIdAsync(project.ProjectID, "ProjectID");

			if (existingProject != null)
			{
				existingProject.IsActive = project.IsActive;

				await _repository.UpdateAsync(existingProject);
			}
		}
	}

}
