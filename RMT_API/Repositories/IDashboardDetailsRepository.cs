using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IDashboardDetailsRepository
	{
		Task<DashboardDetails> GetDashboardDetailsAsync();
	}
}
