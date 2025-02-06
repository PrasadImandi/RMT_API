using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;

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
	}
}
