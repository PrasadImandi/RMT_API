using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.DTOs;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ResourceRepository(ApplicationDBContext _context) : IResourceRepository
	{
		public async Task<IEnumerable<Resource>> GetResourcesByProjectId(int projectId)
		{
			var resources = from resource in _context.Resources
							join deployemnt in _context.ResourceDeployments
							on resource.ID equals deployemnt.ID
							where deployemnt.ID == projectId && deployemnt.IsActive == true
							select new Resource()
							{
								ID = deployemnt.ID,
								FirstName = resource.FirstName,
								LastName = resource.LastName,
								//Email = resource.Email,
								//Phone = resource.Phone,
								//JobTitle = resource.JobTitle,
								//HireDate = resource.HireDate,
								//Status = resource.Status,
								//DepartmentID = resource.DepartmentID,
								//ManagerID = resource.ManagerID
							};

			return await resources.ToListAsync();
		}
	}
}
