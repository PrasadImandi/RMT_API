using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ResourceInformationService(IGenericRepository<ResourceInformation> repository, IMapper mapper) : IResourceInformationService
	{
		public async Task AddResourceInformationAsync(ResourceInformationDto resourceInformation)
		{
			await repository.AddAsync(mapper.Map<ResourceInformation>(resourceInformation));
		}

		public async Task DeleteResourceInformationAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task<ResourceInformationDto> GetRsourceInformatonByIdAsync(int id)
		{
			var response = await repository.GetByIdAsync(id);
			return mapper.Map<ResourceInformationDto>(response);
		}

		public async Task UpdateResourceInfoAsync(ResourceInformationDto resourceInformation)
		{
			await repository.UpdateAsync(mapper.Map<ResourceInformation>(resourceInformation));
		}
	}
}
