using RMT_API.DTOs.ReportsDtos;
using RMT_API.Models;

namespace RMT_API.Services
{
	public interface IReportsService
	{
		Task<IEnumerable<ClientReportsDto>> GetClientReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0);
		Task<IEnumerable<SupplierReportsDto>> GetSupplierReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0);
		Task<IEnumerable<ResourceReportsDto>> GetResourceReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0);
	}
}
