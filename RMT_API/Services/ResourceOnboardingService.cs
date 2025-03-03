using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ResourceOnboardingsService(IGenericRepository<ResourceOnboarding> _repository,
		IResourceOnboardingRepository _onboardingRepository,
		IMapper _mapper) : IResourceOnboardingsService
	{
		public async Task AddResourceOnboardingAsync(ResourceOnboardingDto resourceOnboarding)
		{
			await _repository.AddAsync(_mapper.Map<ResourceOnboarding>(resourceOnboarding));
		}

		public async Task DeleteResourceOnboardingAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ResourceOnboardingDto>> GetAllResourceOnboardingsAsync()
		{
			var response = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<ResourceOnboardingDto>>(response);
		}

		public async Task<ResourceOnboardingDto> GetResourceOnboardingByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<ResourceOnboardingDto>(response);
		}

		public async Task UpdateResourceOnboardingAsync(ResourceOnboardingDto resourceOnboarding)
		{
			await _repository.UpdateAsync(_mapper.Map<ResourceOnboarding>(resourceOnboarding));
		}

		public async Task ChangeStatusResourceOnboardingAsync(ResourceOnboardingDto resourceOnboarding)
		{
			await _repository.ChangeStatusAsync(resourceOnboarding.ID, resourceOnboarding.IsActive);
		}

		public async Task ApproveOnboardingAsync(ResourceOnboardingDto resourceOnboarding)
		{
			await _onboardingRepository.ApproveOnboarding(resourceOnboarding.ID, resourceOnboarding.Remarks, resourceOnboarding.ApprovedDate, resourceOnboarding.Status);
		}
	}
}
