using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ResourceDeploymentsService(IGenericRepository<ResourceDeployment> _repository, IResourceDeploymentRepository resourceDeploymentRepository, IMapper _mapper) : IResourceDeploymentsService
	{
		public async Task AddResourceDeploymentAsync(ResourceDeploymentDto resourceDeployment)
		{
			var checkresourcedeployed = await resourceDeploymentRepository.CheckIfResourceAlreadyDeployed(_mapper.Map<ResourceDeployment>(resourceDeployment));

			if (checkresourcedeployed != null)
			{
				return;
			}

			await _repository.AddAsync(_mapper.Map<ResourceDeployment>(resourceDeployment));
		}

		public async Task DeleteResourceDeploymentAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ResourceDeploymentDto>> GetAllResourceDeploymentsAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await _repository.GetAllAsync(query => query.Skip(pageNumber * pageSize)
																	  .Take(pageSize));
			return _mapper.Map<IEnumerable<ResourceDeploymentDto>>(response);
		}

		public async Task<ResourceDeploymentDto> GetResourceDeploymentByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<ResourceDeploymentDto>(response);
		}

		public async Task UpdateResourceDeploymentAsync(ResourceDeploymentDto resourceDeployment)
		{
			await _repository.UpdateAsync(_mapper.Map<ResourceDeployment>(resourceDeployment));
		}

		public async Task ChangeStatusResourceDeploymentAsync(ResourceDeploymentDto deployment)
		{
			await _repository.ChangeStatusAsync(deployment.ID, deployment.IsActive);
		}
	}
}
