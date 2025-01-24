using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ResourceDeploymentRepository(IGenericRepository<ResourceDeployment> repository, ApplicationDBContext _context) : IResourceDeploymentRepository
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

		public async Task<ResourceDeployment> CheckIfResourceAlreadyDeployed(ResourceDeployment deployment)
			=> await _context!.ResourceDeployments!.FirstOrDefaultAsync(x => x.ResourceID == deployment.ResourceID && x.ProjectID == deployment.ProjectID &&x.Status == "Active");
	}

}
