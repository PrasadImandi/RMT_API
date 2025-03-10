﻿using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class LeaveService(IGenericRepository<Leave> _repository, IMapper _mapper, ILeavesRepository _leavesRepository) : ILeaveService
	{
		public async Task AddLeaveAsync(LeaveDto leave)
		{
			await _repository.AddAsync(_mapper.Map<Leave>(leave));
		}

		public async Task DeleteLeaveAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<LeaveDto>> GetAllLeavesAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await _repository.GetAllAsync(query => query.Skip(pageNumber * pageSize)
			.Take(pageSize));
			return _mapper.Map<IEnumerable<LeaveDto>>(response);
		}

		public async Task<LeaveDto> GetLeaveByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<LeaveDto>(response);
		}

		public async Task UpdateLeaveAsync(LeaveDto leave)
		{
			await _repository.UpdateAsync(_mapper.Map<Leave>(leave));
		}

		public async Task ChangeStatusLeaveAsync(LeaveDto leave)
		{
			await _repository.ChangeStatusAsync(leave.ID, leave.IsActive);
		}

		public async Task ApproveLeavesAsync(LeaveDto leave)
		{
			await _leavesRepository.ApproveLeaves(leave.ID, leave.Remarks, leave.ApprovedDate, leave.Status);
		}
	}
}
