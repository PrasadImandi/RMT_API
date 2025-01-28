using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ResourcesService(IGenericRepository<Resource> _repository, IResourceRepository resourceRepository, IMapper _mapper) : IResourcesService
	{
		public async Task AddResourceAsync(ResourceDto resource)
		{
			await _repository.AddAsync(_mapper.Map<Resource>(resource));
		}

		public async Task DeleteResourceAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync()
		{
			var response = await _repository.GetAllAsync();
			var activeresources = _mapper.Map<IEnumerable<ResourceDto>>(response.Where(x=> (bool)x.IsActive!).ToList());
			return activeresources;
		}

		public async Task<ResourceDto> GetResourceByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<ResourceDto>(response);
		}

		public async Task UpdateResourceAsync(ResourceDto resource)
		{
			await _repository.UpdateAsync(_mapper.Map<Resource>(resource));
		}

		public async Task ChangeStatusResourceAsync(ResourceDto resource)
		{
			await _repository.ChangeStatusAsync(resource.ID, resource.IsActive);
		}

		public async Task<IEnumerable<ResourceDto>> GetResourcesByProjectId(int projectId)
		{
			var response = await resourceRepository.GetResourcesByProjectId(projectId);
			return _mapper.Map<IEnumerable<ResourceDto>>(response);
		}
	}
}
