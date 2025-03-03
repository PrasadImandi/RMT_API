
using Microsoft.EntityFrameworkCore;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ResourceOnboardingRepository(IGenericRepository<ResourceOnboarding> _repository) : IResourceOnboardingRepository
	{
		public async Task ApproveOnboarding(int id, string? remarks, DateTime? ApprovedDate, string? status)
		{
			var resourceOnboarding = await _repository.GetByIdAsync(id);

			if (resourceOnboarding != null)
			{
				resourceOnboarding.Remarks = remarks;
				resourceOnboarding.ApprovedDate = ApprovedDate;
				resourceOnboarding.Status = status;
			}

			await _repository.UpdateAsync(resourceOnboarding);
		}
	}
}
