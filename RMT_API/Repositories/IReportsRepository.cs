using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IReportsRepository
	{
		Task<IEnumerable<ClientReports>> GetClientReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0);
		Task<IEnumerable<SupplierReports>> GetSupplierReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0);
	}
}
