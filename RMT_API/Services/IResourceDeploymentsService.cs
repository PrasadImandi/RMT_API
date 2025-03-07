using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IResourceDeploymentsService
	{
		Task<IEnumerable<ResourceDeploymentDto>> GetAllResourceDeploymentsAsync(string searchText, int pageNumber, int pageSize);
		Task<ResourceDeploymentDto> GetResourceDeploymentByIdAsync(int id);
		Task AddResourceDeploymentAsync(ResourceDeploymentDto resourceDeployment);
		Task UpdateResourceDeploymentAsync(ResourceDeploymentDto resourceDeployment);
		Task DeleteResourceDeploymentAsync(int id);
		Task ChangeStatusResourceDeploymentAsync(ResourceDeploymentDto deployment);
	}
}
