using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ResourceDeploymentRepository(IGenericRepository<ResourceDeployment> repository) : IResourceDeploymentRepository
	{
		private readonly IGenericRepository<ResourceDeployment> _repository = repository;

		public async Task ChangeStatusDeployment(ResourceDeployment deployment)
		{
			var existingDeployment = await _repository.GetByIdAsync(deployment.ResourceID, "DeploymentID");

			if (existingDeployment != null)
			{
				existingDeployment.Status = deployment.Status;

				await _repository.UpdateAsync(existingDeployment);
			}
		}
	}

}
