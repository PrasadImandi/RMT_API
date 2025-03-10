using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IResourceOffboardingsService
	{
		Task<IEnumerable<ResourceOffboardingDto>> GetAllResourceOffboardingsAsync(string searchText, int pageNumber, int pageSize);
		Task<ResourceOffboardingDto> GetResourceOffboardingByIdAsync(int id);
		Task AddResourceOffboardingAsync(ResourceOffboardingDto resourceOffboarding);
		Task UpdateResourceOffboardingAsync(ResourceOffboardingDto resourceOffboarding);
		Task DeleteResourceOffboardingAsync(int id);
		Task ChangeStatusResourceOffboardingAsync(ResourceOffboardingDto resourceOffboarding);
	}
}
