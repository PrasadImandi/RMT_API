using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ResourceDeploymentRepository(ApplicationDBContext _context) : IResourceDeploymentRepository
	{
		public async Task<ResourceDeployment> CheckIfResourceAlreadyDeployed(ResourceDeployment deployment)
		{
			var response= await _context!.ResourceDeployments!.FirstOrDefaultAsync(x => x.ResourceID == deployment.ResourceID && x.ProjectID == deployment.ProjectID && x.IsActive == true);
			return response!;
		}
	}

}
