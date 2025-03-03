namespace RMT_API.Repositories
{
	public interface IResourceOnboardingRepository
	{
		Task ApproveOnboarding(int id, string? remarks, DateTime? ApprovedDate, string? status);
	}
}
