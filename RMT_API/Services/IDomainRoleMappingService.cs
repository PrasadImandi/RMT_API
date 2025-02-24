using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IDomainRoleMappingService
	{
		Task<IEnumerable<DomainRoleMappingDto>> GetAllDomainRoleMappingsAsync();
		Task<DomainRoleMappingDto> GetDomainRoleMappingByIdAsync(int id);
		Task AddDomainRoleMappingAsync(DomainRoleMappingDto domainRoleMapping);
		Task UpdateDomainRoleMappingAsync(DomainRoleMappingDto domainRoleMapping);
		Task DeleteDomainRoleMappingAsync(int id);
		Task ChangeStatusDomainRoleMappingAsync(DomainRoleMappingDto domainRoleMapping);
	}
}
