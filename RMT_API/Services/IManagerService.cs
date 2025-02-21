using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IManagerService
	{
		Task<IEnumerable<ManagerDto>> GetAllManagersAsync();
		Task<IEnumerable<ManagerDto>> GetProjectManagersByProjectIdAsync(int projectId);
		Task<IEnumerable<ManagerDto>> GetReportingManagersByProjectIdAsync(int projectId);
		Task<ManagerDto> GetManagerByIdAsync(int id);
		Task AddManagerAsync(ManagerDto accessType);
		Task UpdateManagerAsync(ManagerDto accessType);
		Task DeleteManagerAsync(int id);
		Task ChangeStatusManagerAsync(ManagerDto accessType);
	}
}
