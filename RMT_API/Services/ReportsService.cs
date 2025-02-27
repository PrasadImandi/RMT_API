using AutoMapper;
using RMT_API.DTOs.ReportsDtos;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ReportsService(IReportsRepository _reportsRepository, IMapper _mapper) : IReportsService
	{
		public async Task<IEnumerable<ClientReportsDto>> GetClientReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0)
		{
			var results = await _reportsRepository.GetClientReportsAsync(filterType, searchName, pageNumber, pageSize);

			return _mapper.Map<IEnumerable<ClientReportsDto>>(results);
		}

		public async Task<IEnumerable<SupplierReportsDto>> GetSupplierReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0)
		{
			var results = await _reportsRepository.GetSupplierReportsAsync(filterType, searchName, pageNumber, pageSize);

			return _mapper.Map<IEnumerable<SupplierReportsDto>>(results);
		}
	}
}
