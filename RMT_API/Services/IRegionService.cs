using RMT_API.DTOs.BaseDtos;

namespace RMT_API.Services
{
	public interface IRegionService
	{
		Task<IEnumerable<BaseDto>> GetAllRegionsAsync();
		Task<BaseDto> GetRegionByIdAsync(int id);
		Task AddRegionAsync(BaseDto region);
		Task UpdateRegionAsync(BaseDto region);
		Task DeleteRegionAsync(int id);
		Task ChangeStatusRegionAsync(BaseDto region);
	}
}
