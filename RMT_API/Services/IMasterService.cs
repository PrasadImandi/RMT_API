﻿using RMT_API.DTOs.BaseDtos;

namespace RMT_API.Services
{
	public interface IMasterService
	{
		Task<IEnumerable<BaseDto>> GetAllMastersAsync(string MasterType, string searchText, int pageNumber, int pageSize, int? domainId);
		Task AddMasterAsync(string MasterType, BaseDto master);
		Task UpdateMasterAsync(string MasterType, BaseDto master);
		Task DeleteMasterAsync(string MasterType, int id);
		Task ChangeStatusMasterAsync(string MasterType, BaseDto master);
	}
}
