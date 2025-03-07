using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Infrastructure.Enums;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ResourcesService(IGenericRepository<Resource> _repository,
								  IGenericRepository<Users> _userRepository,
								  IResourceRepository resourceRepository,
								  IMapper _mapper) : IResourcesService
	{
		public async Task AddResourceAsync(ResourceDto resource)
		{
			if (resource?.IsAddUser == true)
			{
				Users newUser = new Users()
				{
					AccessTypeID = (int)AccessTypeEnum.Resource,
					FirstName = resource.FirstName,
					LastName = resource.LastName,
					Email = resource.EmailID,
					IsActive = resource.IsActive,
				};

				await _userRepository.AddAsync(newUser);

				resource.UserID = newUser.ID;
			}

			await _repository.AddAsync(_mapper.Map<Resource>(resource));

		}

		public async Task DeleteResourceAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync(string searchText, int pageNumber = 0, int pageSize = 10)
		{
			var response = await _repository.GetAllAsync(query => query.Where(p => p.FirstName!.Contains(searchText) || p.LastName!.Contains(searchText))
																	  .Skip(pageNumber * pageSize)
																	  .Take(pageSize));
			var activeresources = _mapper.Map<IEnumerable<ResourceDto>>(response);
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
