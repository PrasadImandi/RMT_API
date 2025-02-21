using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IManagerRepository
	{
		Task<IEnumerable<Manager>> GetProjectManagersByProjectIdAsync(int projectId);
		Task<IEnumerable<Manager>> GetReportingManagersByProjectIdAsync(int projectId);
	}
}
