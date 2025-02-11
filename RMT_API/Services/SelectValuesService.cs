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
									 IGenericRepository<DomainMaster> _domainRepository,
									 IGenericRepository<DomainRoleMaster> _domainRoleRepository,
									 IGenericRepository<DomainLevelMaster> _domainlevelRepository,
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
			var locations = await _locationRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(locations);
		}

		public async Task<IEnumerable<BaseDto>> DomainIDNameListAsync()
		{
			var domains = await _domainRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(domains);
		}

		public async Task<IEnumerable<BaseDto>> DomainRoleIDNameListAsync()
		{
			var domainroles = await _domainRoleRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(domainroles);
		}

		public async Task<IEnumerable<BaseDto>> DomainLevelIDNameListAsync()
		{
			var domainlevels = await _domainlevelRepository.GetAllActiveAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(domainlevels);
		}
	}
}
