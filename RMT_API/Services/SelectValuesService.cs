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
									 IDomainRoleRepository domainRoleRepository,
									 IMapper _mapper) : ISelectValuesService
	{
		public async Task<IEnumerable<BaseDto>> ClientIDNameListAsync()
		{
			var clients =await _clientRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}

		public async Task<IEnumerable<BaseDto>> StateIDNameListAsync()
		{
			var clients = await _stateRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}

		public async Task<IEnumerable<BaseDto>> PinCodeIDNameListAsync()
		{
			var clients = await _pincodeRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}

		public async Task<IEnumerable<BaseDto>> RegionIDNameListAsync()
		{
			var clients = await _regionRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}

		public async Task<IEnumerable<BaseDto>> SPOCIDNameListAsync()
		{
			var clients = await _spocRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(clients);
		}

		public async Task<IEnumerable<BaseDto>> LocationIDNameListAsync()
		{
			var locations = await _locationRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(locations);
		}

		public async Task<IEnumerable<BaseDto>> DomainIDNameListAsync()
		{
			var domains = await _domainRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(domains);
		}

		public async Task<IEnumerable<BaseDto>> DomainRoleIDNameListAsync()
		{
			var domainroles = await _domainRoleRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(domainroles);
		}

		public async Task<IEnumerable<BaseDto>> DomainLevelIDNameListAsync()
		{
			var domainlevels = await _domainlevelRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<BaseDto>>(domainlevels);
		}

		public async Task<IEnumerable<BaseDto>> DomainRoleIDNameListByDomainIdAsync(int domainId)
		{
			var domainroles = await domainRoleRepository.GetDomainRolesByDomainIdAsync(domainId);

			return _mapper.Map<IEnumerable<BaseDto>>(domainroles);
		}
	}
}
