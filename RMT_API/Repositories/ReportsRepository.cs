using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ReportsRepository(ApplicationDBContext _context) : IReportsRepository
	{
		public async Task<IEnumerable<ClientReports>> GetClientReportsAsync(int clientId = 0, int projectId = 0, int pmid = 0, int rmid = 0)
		{
			// Define the stored procedure call and pass parameters
			var clientIdParam = clientId;  // Ensure we pass an empty string if null
			var projectIdParam = projectId;
			var pmidParam = pmid;
			var rmidParam = rmid;

			// Using FromSqlRaw for executing the stored procedure
			var clientReports = await _context.ClientReports
				.FromSqlRaw("EXEC AccountMasterReports @ClientID = {0}, @ProjectID = {1}, @PMID = {2}, @RMID = {3}",
					clientIdParam, projectIdParam, pmidParam, rmidParam)
				.ToListAsync();

			return clientReports;
		}
	}
}
