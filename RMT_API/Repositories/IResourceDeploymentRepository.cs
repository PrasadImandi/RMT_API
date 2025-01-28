using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IResourceDeploymentRepository
	{
		Task<ResourceDeployment> CheckIfResourceAlreadyDeployed(ResourceDeployment deployment);
	}
}
