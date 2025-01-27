using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IAccessTypeService
	{
		Task<IEnumerable<AccessTypeMasterDto>> GetAllAccessTypesAsync();
		Task<AccessTypeMasterDto> GetAccessTypeByIdAsync(int id);
		Task AddAccessTypeAsync(AccessTypeMasterDto accessType);
		Task UpdateAccessTypeAsync(AccessTypeMasterDto accessType);
		Task DeleteAccessTypeAsync(int id);
		Task ChangeStatusAccessTypeAsync(AccessTypeMasterDto accessType);
	}
}
