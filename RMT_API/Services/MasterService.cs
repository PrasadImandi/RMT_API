﻿using AutoMapper;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class MasterService(IMapper _mapper, IRepositoryFactory _repositoryFactory) : IMasterService
	{
		public async Task AddMasterAsync(string MasterType, BaseDto master)
		{
			if (MasterType.Equals("ContactType", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<ContactTypeMaster>();
				await _repository.AddAsync(_mapper.Map<ContactTypeMaster>(master));
			}
			else if (MasterType.Equals("DeliveryMotion", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<DeliveryMotionMaster>();
				await _repository.AddAsync(_mapper.Map<DeliveryMotionMaster>(master));
			}
			else if (MasterType.Equals("Domain", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<DomainMaster>();
				await _repository.AddAsync(_mapper.Map<DomainMaster>(master));
			}
			else if (MasterType.Equals("DomainRole", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<DomainRoleMaster>();
				await _repository.AddAsync(_mapper.Map<DomainRoleMaster>(master));
			}
			else if (MasterType.Equals("DomainLevel", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<DomainLevelMaster>();
				await _repository.AddAsync(_mapper.Map<DomainLevelMaster>(master));
			}
		}

		public Task ChangeStatusMasterAsync(string MasterType, BaseDto master)
		{
			throw new NotImplementedException();
		}

		public Task DeleteMasterAsync(string MasterType, int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<BaseDto>> GetAllMastersAsync(string MasterType)
		{
			IEnumerable<BaseDto> result = new List<BaseDto>();

			if (MasterType.Equals("ContactType", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<ContactTypeMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("DeliveryMotion", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<DeliveryMotionMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("Domain", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<DomainMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("DomainLevel", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<DomainLevelMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("DomainRole", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<DomainRoleMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("Forms", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<FormMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("LaptopProvider", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<LaptopProviderMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("LeaveType", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<LeaveTypeMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("Location", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<LocationMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("ManagerType", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<ManagerTypeMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("PinCode", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<PincodeMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("publicHolidays", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<PublicHolidayMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("regions", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<RegionMater>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("segments", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<SegmentMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}
			else if (MasterType.Equals("supportType", StringComparison.OrdinalIgnoreCase))
			{
				var _repository = _repositoryFactory.GetRepository<SupportTypeMaster>();
				var response = await _repository.GetAllActiveAsync();
				result = _mapper.Map<IEnumerable<BaseDto>>(response);
			}

			return result;
		}

		public Task<BaseDto> GetMasterByIdAsync(string MasterType, int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateMasterAsync(string MasterType, BaseDto master)
		{
			throw new NotImplementedException();
		}
	}
}
