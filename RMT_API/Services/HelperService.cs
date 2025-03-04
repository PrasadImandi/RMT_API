using AutoMapper;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class HelperService(IHelperRepository _repository,IMapper mapper) : IHelperService
	{
		public async Task<IEnumerable<BaseDto>> GetLeftNavItemsByRoleIdAsync(int id)
		{
			var result = await _repository.GetLeftNavItemsByRoleIdAsync(id);

			return mapper.Map<IEnumerable<BaseDto>>(result);
		}
	}
}
