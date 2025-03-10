using RMT_API.DTOs.ReportsDtos;
using RMT_API.Models;

namespace RMT_API.Services
{
	public interface IReportsService
	{
		Task<IEnumerable<ClientReportsDto>> GetClientReportsAsync(string filterType, string searchName, int pageNumber, int pageSize);
		Task<IEnumerable<SupplierReportsDto>> GetSupplierReportsAsync(string filterType, string searchName, int pageNumber, int pageSize);
		Task<IEnumerable<ResourceReportsDto>> GetResourceReportsAsync(string filterType, string searchName, int pageNumber, int pageSize);
		Task<IEnumerable<ProjectReportsDto>> GetProjectReportsAsync(string filterType, string searchName, int pageNumber, int pageSize);
	}
}
