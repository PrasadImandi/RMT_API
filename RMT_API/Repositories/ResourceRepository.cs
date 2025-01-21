using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.DTOs;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ResourceRepository(IGenericRepository<Resource> _repository, ApplicationDBContext _context) : IResourceRepository
	{
		public async Task ChangeStatusResource(Resource resource)
		{
			var existingResource = _repository.GetByIdAsync(resource.ResourceID, "ResourceID").Result;

			if (existingResource != null)
			{
				existingResource.Status = resource.Status;

				await _repository.UpdateAsync(existingResource);
			}
		}

		public async Task<IEnumerable<Resource>> GetResourcesByProjectId(int projectId)
		{
			var resources = from resource in _context.Resources
							join deployemnt in _context.ResourceDeployments
							on resource.ResourceID equals deployemnt.ResourceID
							where deployemnt.ProjectID == projectId && deployemnt.Status == "Active"
							select new Resource()
							{
								ResourceID = deployemnt.DeploymentID,
								FirstName = resource.FirstName,
								LastName = resource.LastName,
								Email = resource.Email,
								Phone = resource.Phone,
								JobTitle = resource.JobTitle,
								HireDate = resource.HireDate,
								Status = resource.Status,
								DepartmentID = resource.DepartmentID,
								ManagerID = resource.ManagerID,
								DeployementID = deployemnt.DeploymentID
							};

			return await resources.ToListAsync();
		}
	}
}
