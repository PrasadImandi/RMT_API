
using Microsoft.EntityFrameworkCore;
using RMT_API.Data;

namespace RMT_API.Repositories
{
	public class LeavesRepository(ApplicationDBContext _context) : ILeavesRepository
	{
		public async Task ApproveLeaves(int id, string? remarks,DateTime? ApprovedDate, string? status)
		{
			var leaveItem = await _context.Leaves.FirstOrDefaultAsync(x => x.ID == id);

			if (leaveItem != null)
			{
				leaveItem.Remarks = remarks;
				leaveItem.ApprovedDate = ApprovedDate;
				leaveItem.Status = status;
			}

			await _context.SaveChangesAsync();
		}
	}
}
