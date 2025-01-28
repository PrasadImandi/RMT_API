using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ResourceOffboardingsService(IGenericRepository<ResourceOffboarding> _repository,
		IMapper _mapper) : IResourceOffboardingsService
	{
		public async Task AddResourceOffboardingAsync(ResourceOffboardingDto resourceOffboarding)
		{
			await _repository.AddAsync(_mapper.Map<ResourceOffboarding>(resourceOffboarding));
		}

		public async Task DeleteResourceOffboardingAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ResourceOffboardingDto>> GetAllResourceOffboardingsAsync()
		{
			var response = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<ResourceOffboardingDto>>(response);
		}

		public async Task<ResourceOffboardingDto> GetResourceOffboardingByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<ResourceOffboardingDto>(response);
		}

		public async Task UpdateResourceOffboardingAsync(ResourceOffboardingDto resourceOffboarding)
		{
			await _repository.UpdateAsync(_mapper.Map<ResourceOffboarding>(resourceOffboarding));
		}

		public async Task ChangeStatusResourceOffboardingAsync(ResourceOffboardingDto resourceOffboarding)
		{
			await _repository.ChangeStatusAsync(resourceOffboarding.OffboardingID, resourceOffboarding.IsActive);
		}
	}
}
