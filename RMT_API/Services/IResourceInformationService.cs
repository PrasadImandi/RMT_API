using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IResourceInformationService
	{
		Task<ResourceInformationDto> GetRsourceInformatonByIdAsync(int id);
		Task AddResourceInformationAsync(ResourceInformationDto resourceInformation);
		Task UpdateResourceInfoAsync(ResourceInformationDto resourceInformation);
		Task DeleteResourceInformationAsync(int id);
		Task DeleteAcademicDetailsAsync(int id);
		Task DeleteCertificationDetailsAsync(int id);
		Task DeleteBGVDocsAsync(int id);
		Task<ResourceInformationDto> GetResourceByUserIdAsync(int userId);

	}
}
