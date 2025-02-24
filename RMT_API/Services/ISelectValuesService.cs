using RMT_API.DTOs.BaseDtos;

namespace RMT_API.Services
{
	public interface ISelectValuesService
	{

		Task<IEnumerable<BaseDto>> ClientIDNameListAsync();
		Task<IEnumerable<BaseDto>> StateIDNameListAsync();
		Task<IEnumerable<BaseDto>> PinCodeIDNameListAsync();
		Task<IEnumerable<BaseDto>> RegionIDNameListAsync();
		Task<IEnumerable<BaseDto>> SPOCIDNameListAsync();
		Task<IEnumerable<BaseDto>> LocationIDNameListAsync();
		Task<IEnumerable<BaseDto>> DomainIDNameListAsync();
		Task<IEnumerable<BaseDto>> DomainRoleIDNameListAsync();
		Task<IEnumerable<BaseDto>> DomainLevelIDNameListAsync();


		Task<IEnumerable<BaseDto>> CreateStateAsync();
		Task<IEnumerable<BaseDto>> CreatePinCodeAsync();
		Task<IEnumerable<BaseDto>> CreateRegionAsync();
		Task<IEnumerable<BaseDto>> CreateSPOCAsync();
		Task<IEnumerable<BaseDto>> CreateLocationAsync();
		Task<IEnumerable<BaseDto>> CreateDomainAsync();
		Task<IEnumerable<BaseDto>> CreateDomainRoleAsync();
		Task<IEnumerable<BaseDto>> CreateDomainLevelAsync();
	}
}
