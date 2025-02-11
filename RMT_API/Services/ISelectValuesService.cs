using RMT_API.DTOs.BaseDtos;

namespace RMT_API.Services
{
	public interface ISelectValuesService
	{

		Task<IEnumerable<BaseDto>> ClientIDNameListAsync();
		Task<IEnumerable<BaseDto>> StateIDNameListAsync();
		Task<IEnumerable<BaseDto>> PincodeIDNameListAsync();
		Task<IEnumerable<BaseDto>> RegionIDNameListAsync();
		Task<IEnumerable<BaseDto>> SPOCIDNameListAsync();
		Task<IEnumerable<BaseDto>> LocationIDNameListAsync();

		Task<IEnumerable<BaseDto>> DomainIDNameListAsync();
		Task<IEnumerable<BaseDto>> DomainRoleIDNameListAsync();
		Task<IEnumerable<BaseDto>> DomainLevelIDNameListAsync();
	}
}
RG