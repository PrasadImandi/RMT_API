using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.DTOs;
using RMT_API.Infrastructure.Enums;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ManagerRepository(ApplicationDBContext _context) : IManagerRepository
	{
		public async Task<IEnumerable<Manager>> GetProjectManagersByProjectIdAsync(int projectId)
		{
			var response =await _context.Manager
									.Where(manager => manager.ManagerTypeID == (int)ManagerTypeEnum.ProjectManager)  // Filter ManagerType
									.Join(
										_context.Projects,
										manager => manager.ID,    // Key selector for Manager
										project => project.PMID,  // Key selector for Project
										(manager, project) => manager  // Projection to return only Manager
									)
									.ToListAsync();

			return response;
		}

		public async Task<IEnumerable<Manager>> GetReportingManagersByProjectIdAsync(int projectId)
		{
			var response = await _context.Manager
									.Where(manager => manager.ManagerTypeID == (int)ManagerTypeEnum.ReportingManager)  // Filter ManagerType
									.Join(
										_context.Projects,
										manager => manager.ID,    // Key selector for Manager
										project => project.RMID,  // Key selector for Project
										(manager, project) => manager  // Projection to return only Manager
									)
									.ToListAsync();

			return response;
		}
	}
}
