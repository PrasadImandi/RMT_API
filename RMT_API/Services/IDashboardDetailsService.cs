using RMT_API.DTOs;
using RMT_API.Models;

namespace RMT_API.Services
{
	public interface IDashboardDetailsService
	{
		Task<DashboardDetails> GetDashboardDetailsAsync();
	}
}
