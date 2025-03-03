namespace RMT_API.Repositories
{
	public interface ILeavesRepository
	{
		Task ApproveLeaves(int id, string? remarks, DateTime? ApprovedDate, string? status);
	}
}
