using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IResourceDeploymentRepository
	{
		Task ChangeStatusDeployment(ResourceDeployment deployment);
		Task<ResourceDeployment> CheckIfResourceAlreadyDeployed(ResourceDeployment deployment);
	}
}
