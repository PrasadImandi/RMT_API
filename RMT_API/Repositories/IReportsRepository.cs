using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IReportsRepository
	{
		Task<IEnumerable<ClientReports>> GetClientReportsAsync(int clientId = 0, int projectId = 0, int pmid = 0, int rmid = 0);
	}
}
