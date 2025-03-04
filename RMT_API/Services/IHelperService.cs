using RMT_API.DTOs.BaseDtos;

namespace RMT_API.Services
{
	public interface IHelperService
	{
		Task<IEnumerable<BaseDto>> GetLeftNavItemsByRoleIdAsync(int id);
	}
}
