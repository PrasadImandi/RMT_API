using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ResourceInformationService(IGenericRepository<ResourceInformation> repository,
											IGenericRepository<AcademicDetails> _academicRepository,
											IGenericRepository<CertificationDetails> _certificationRepository,
											IGenericRepository<BGVDocuments> _bgvDocsRepository,
											IGenericRepository<Resource> _resourceRepository,
											IResourceRepository resourceRepository,
											IMapper mapper) : IResourceInformationService
	{
		public async Task AddResourceInformationAsync(ResourceInformationDto resourceInformation)
		{
			var response = await repository.AddAsync(mapper.Map<ResourceInformation>(resourceInformation));

			var resource = await _resourceRepository.GetByIdAsNoTrackingAsync(response.ResourceID);

			if (resource != null)
			{
				resource.ResourceInformationID = response.ID;
				await _resourceRepository.UpdateAsync(resource);
			}
		}

		public async Task DeleteResourceInformationAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task DeleteAcademicDetailsAsync(int id)
		{
			await _certificationRepository.DeleteAsync(id);
		}

		public async Task DeleteCertificationDetailsAsync(int id)
		{
			await _academicRepository.DeleteAsync(id);
		}

		public async Task DeleteBGVDocsAsync(int id)
		{
			await _bgvDocsRepository.DeleteAsync(id);
		}

		public async Task<ResourceInformationDto> GetResourceInformationByIdAsync(int id)
		{
			var response = await repository.GetSingleAsync(p => p.ID == id,
																	  query => query.Include(p => p.Personal)
																					.Include(p => p.Professional)
																					.Include(p => p.AcademicDetails)
																					.Include(p => p.Documents)
																					.ThenInclude(dm => dm!.BGV)
																					.Include(p => p.Documents)
																					.ThenInclude(dm => dm!.Joining)
																					.Include(p => p.Certifications));

			return mapper.Map<ResourceInformationDto>(response);
		}

		public async Task UpdateResourceInfoAsync(ResourceInformationDto resourceInformation)
		{
			var response = await repository.GetSingleAsync(p => p.ID == resourceInformation.ID,
																	  query => query.Include(p => p.Personal)
																					.Include(p => p.Professional)
																					.Include(p => p.AcademicDetails)
																					.Include(p => p.Documents)
																					.ThenInclude(dm => dm!.BGV)
																					.Include(p => p.Documents)
																					.ThenInclude(dm => dm!.Joining)
																					.Include(p => p.Certifications).AsNoTracking());

			response = mapper.Map<ResourceInformation>(resourceInformation);

			await repository.UpdateAsync(response);
		}

		public async Task<ResourceInformationDto> GetResourceByUserIdAsync(int userId)
		{
			var response = await resourceRepository.GetResourceByUserId(userId);
			return mapper.Map<ResourceInformationDto>(response);
		}
	}
}
