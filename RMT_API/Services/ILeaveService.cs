using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface ILeaveService
	{
		Task<IEnumerable<LeaveDto>> GetAllLeavesAsync(string searchText, int pageNumber, int pageSize);
		Task<LeaveDto> GetLeaveByIdAsync(int id);
		Task AddLeaveAsync(LeaveDto leave);
		Task UpdateLeaveAsync(LeaveDto leave);
		Task DeleteLeaveAsync(int id);
		Task ChangeStatusLeaveAsync(LeaveDto leave);
		Task ApproveLeavesAsync(LeaveDto leave);
	}
}
