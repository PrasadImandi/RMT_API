using AutoMapper;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class SelectValuesService(IGenericRepository<Client> _clientRepository,
									 IGenericRepository<StateMaster> _stateRepository,
									 IGenericRepository<PincodeMaster> _pincodeRepository,
									 IGenericRepository<RegionMater> _regionRepository,
									 IGenericRepository<SPOC> _spocRepository,
									 IGenericRepository<LocationMaster> _locationRepository,
									 IMapper _mapper) : ISelectValuesService
	{
		public async Task<IEnumerable<BaseDto>> ClientIDNameListAsync()
		{
			var clients =await _clientRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}


		public async Task<IEnumerable<BaseDto>> StateIDNameListAsync()
		{
			var clients = await _stateRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}


		public async Task<IEnumerable<BaseDto>> PincodeIDNameListAsync()
		{
			var clients = await _pincodeRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}


		public async Task<IEnumerable<BaseDto>> RegionIDNameListAsync()
		{
			var clients = await _regionRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}


		public async Task<IEnumerable<BaseDto>> SPOCIDNameListAsync()
		{
			var clients = await _spocRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}


		public async Task<IEnumerable<BaseDto>> LocationIDNameListAsync()
		{
			var clients = await _locationRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}
	}
}
