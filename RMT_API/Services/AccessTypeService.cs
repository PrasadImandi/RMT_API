using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class AccessTypeService(IGenericRepository<AccessTypeMaster> repository, IMapper mapper) : IAccessTypeService
	{
		public async Task AddAccessTypeAsync(AccessTypeMasterDto accessType)
		{
			await repository.AddAsync(mapper.Map<AccessTypeMaster>(accessType));
		}

		public async Task ChangeStatusAccessTypeAsync(AccessTypeMasterDto accessType)
		{
			await repository.ChangeStatusAsync(accessType.ID, accessType.IsActive);
		}

		public async Task DeleteAccessTypeAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task<AccessTypeMasterDto> GetAccessTypeByIdAsync(int id)
		{
			var response = await repository.GetByIdAsync(id);
			return mapper.Map<AccessTypeMasterDto>(response);
		}

		public async Task<IEnumerable<AccessTypeMasterDto>> GetAllAccessTypesAsync()
		{
			var response = await repository.GetAllAsync();
			return mapper.Map<IEnumerable<AccessTypeMasterDto>>(response);
		}

		public async Task UpdateAccessTypeAsync(AccessTypeMasterDto accessType)
		{
			await repository.UpdateAsync(mapper.Map<AccessTypeMaster>(accessType));
		}
	}
}
