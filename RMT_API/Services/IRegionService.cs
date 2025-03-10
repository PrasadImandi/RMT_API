using RMT_API.DTOs.BaseDtos;

namespace RMT_API.Services
{
	public interface IRegionService
	{
		Task<IEnumerable<BaseDto>> GetAllRegionsAsync(string searchText, int pageNumber, int pageSize);
		Task<BaseDto> GetRegionByIdAsync(int id);
		Task AddRegionAsync(BaseDto region);
		Task UpdateRegionAsync(BaseDto region);
		Task DeleteRegionAsync(int id);
		Task ChangeStatusRegionAsync(BaseDto region);
	}
}
