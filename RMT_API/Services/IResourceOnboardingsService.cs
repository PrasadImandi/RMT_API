using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IResourceOnboardingsService
	{
		Task<IEnumerable<ResourceOnboardingDto>> GetAllResourceOnboardingsAsync();
		Task<ResourceOnboardingDto> GetResourceOnboardingByIdAsync(int id);
		Task AddResourceOnboardingAsync(ResourceOnboardingDto resourceOnboarding);
		Task UpdateResourceOnboardingAsync(ResourceOnboardingDto resourceOnboarding);
		Task DeleteResourceOnboardingAsync(int id);
		Task ChangeStatusResourceOnboardingAsync(ResourceOnboardingDto resourceOnboarding);
		Task ApproveOnboardingAsync(ResourceOnboardingDto resourceOnboarding);
	}
}
