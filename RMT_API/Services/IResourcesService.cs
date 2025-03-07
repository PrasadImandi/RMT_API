using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IResourcesService
	{
		Task<IEnumerable<ResourceDto>> GetAllResourcesAsync(string searchText, int pageNumber, int pageSize);
		Task<ResourceDto> GetResourceByIdAsync(int id);
		Task<IEnumerable<ResourceDto>> GetResourcesByProjectId(int projectId);
		Task AddResourceAsync(ResourceDto resource);
		Task UpdateResourceAsync(ResourceDto resource);
		Task DeleteResourceAsync(int id);
		Task ChangeStatusResourceAsync(ResourceDto resource); 
	}
}
