using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class DashboardDetailsService(IDashboardDetailsRepository _repository) : IDashboardDetailsService
	{
		public async Task<DashboardDetails> GetDashboardDetailsAsync()
		{
			 return await _repository.GetDashboardDetailsAsync();
		}
	}
}
