using RMT_API.DTOs.ReportsDtos;
using RMT_API.Models;

namespace RMT_API.Services
{
	public interface IReportsService
	{
		Task<IEnumerable<ClientReportsDto>> GetClientReportsAsync(int clientId = 0, int projectId = 0, int pmid = 0, int rmid = 0);
	}
}
