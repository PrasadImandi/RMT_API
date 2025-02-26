using AutoMapper;
using RMT_API.DTOs.ReportsDtos;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ReportsService(IReportsRepository _reportsRepository,IMapper _mapper) : IReportsService
	{
		public async Task<IEnumerable<ClientReportsDto>> GetClientReportsAsync(int clientId = 0, int projectId = 0, int pmid = 0, int rmid = 0)
		{
			var results = await _reportsRepository.GetClientReportsAsync(clientId, projectId,pmid,rmid);

			return _mapper.Map<IEnumerable<ClientReportsDto>>(results);
		}
	}
}
