using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
							on resource.ID equals deployemnt.ResourceID
							where deployemnt.ProjectID == projectId && deployemnt.IsActive == true
							select new Resource()
							{
								ID = deployemnt.ID,
								FirstName = resource.FirstName,
								LastName = resource.LastName,
								EmailID = resource.EmailID,
								MobileNumber = resource.MobileNumber,
								//JobTitle = resource.JobTitle,
								//HireDate = resource.HireDate,
								IsActive = resource.IsActive,
								//DepartmentID = resource.DepartmentID,
								//ManagerID = resource.ManagerID
							};

			return await resources.ToListAsync();
		}

		public async Task<ResourceInformation> GetResourceByUserId(int userId)
		{
			var resourceDetails = await _context.ResourceInformation
										.Include(x => x.ResourceDetails)
										.Include(x=>x.Professional)
										.Where(r => r.ResourceDetails.UserID == userId && r.ResourceDetails.IsActive == true)
										.FirstOrDefaultAsync();
				
			return resourceDetails;
		}
	}
}
