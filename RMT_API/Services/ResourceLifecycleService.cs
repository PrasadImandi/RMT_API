using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ResourceLifecyclesService(IGenericRepository<ResourceLifecycle> _repository,
		 IMapper _mapper) : IResourceLifecyclesService
	{
		public async Task AddResourceLifecycleAsync(ResourceLifeCycleDto resourceLifecycle)
		{
			await _repository.AddAsync(_mapper.Map<ResourceLifecycle>(resourceLifecycle));
		}

		public async Task DeleteResourceLifecycleAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ResourceLifeCycleDto>> GetAllResourceLifecyclesAsync()
		{
			var response = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<ResourceLifeCycleDto>>(response);
		}

		public async Task<ResourceLifeCycleDto> GetResourceLifecycleByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<ResourceLifeCycleDto>(response);
		}

		public async Task UpdateResourceLifecycleAsync(ResourceLifeCycleDto resourceLifecycle)
		{
			await _repository.UpdateAsync(_mapper.Map<ResourceLifecycle>(resourceLifecycle));
		}

		public async Task ChangeStatusResourceLifecycleAsync(ResourceLifeCycleDto resourceLifecycle)
		{
			await _repository.ChangeStatusAsync(resourceLifecycle.ID, resourceLifecycle.IsActive);
		}
	}
}
