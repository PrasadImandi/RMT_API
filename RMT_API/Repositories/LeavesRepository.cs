
using RMT_API.Data;

namespace RMT_API.Repositories
{
	public class LeavesRepository(ApplicationDBContext _context) : ILeavesRepository
	{
		public async Task ApproveLeaves(int id, string? remarks,DateTime? ApprovedDate, string? status)
		{
			var leaveItem = _context.Leaves.Where(x => x.ID == id);
		}
	}
}
