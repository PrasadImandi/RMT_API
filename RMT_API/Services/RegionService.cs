using AutoMapper;
using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class RegionService(IGenericRepository<RegionMater> repository, IMapper mapper) : IRegionService
	{
		public async Task AddRegionAsync(BaseDto region)
		{
			await repository.AddAsync(mapper.Map<RegionMater>(region));
		}

		public async Task ChangeStatusRegionAsync(BaseDto region)
		{
			await repository.ChangeStatusAsync(region.ID, region.IsActive);
		}

		public async Task DeleteRegionAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<BaseDto>> GetAllRegionsAsync()
		{
			var response = await repository.GetAllAsync();
			return mapper.Map<IEnumerable<BaseDto>>(response);
		}

		public async Task<BaseDto> GetRegionByIdAsync(int id)
		{
			var response = await repository.GetByIdAsync(id);
			return mapper.Map<BaseDto>(response);
		}

		public async Task UpdateRegionAsync(BaseDto region)
		{
			await repository.UpdateAsync(mapper.Map<RegionMater>(region));
		}
	}
}
