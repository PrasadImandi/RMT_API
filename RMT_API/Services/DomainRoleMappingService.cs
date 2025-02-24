using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models.MappingModels;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class DomainRoleMappingService(IGenericRepository<DomainRoleMapping> repository, IMapper mapper) : IDomainRoleMappingService
	{
		public async Task AddDomainRoleMappingAsync(DomainRoleMappingDto domainRoleMapping)
		{
			await repository.AddAsync(mapper.Map<DomainRoleMapping>(domainRoleMapping));
		}

		public async Task ChangeStatusDomainRoleMappingAsync(DomainRoleMappingDto domainRoleMapping)
		{
			await repository.ChangeStatusAsync(domainRoleMapping.ID, domainRoleMapping.IsActive);
		}

		public async Task DeleteDomainRoleMappingAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<DomainRoleMappingDto>> GetAllDomainRoleMappingsAsync()
		{
			var response = await repository.GetAllAsync();
			return mapper.Map<IEnumerable<DomainRoleMappingDto>>(response);
		}

		public async Task<DomainRoleMappingDto> GetDomainRoleMappingByIdAsync(int id)
		{
			var response = await repository.GetByIdAsync(id);
			return mapper.Map<DomainRoleMappingDto>(response);
		}

		public async Task UpdateDomainRoleMappingAsync(DomainRoleMappingDto domainRoleMapping)
		{
			await repository.UpdateAsync(mapper.Map<DomainRoleMapping>(domainRoleMapping));
		}
	}
}
