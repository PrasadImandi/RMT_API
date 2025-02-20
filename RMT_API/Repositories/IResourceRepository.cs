using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IResourceRepository
	{
		Task<IEnumerable<Resource>> GetResourcesByProjectId(int projectId);
		Task<ResourceInformation> GetResourceByUserId(int userId);
	}
}
