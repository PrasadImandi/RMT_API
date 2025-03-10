﻿using AutoMapper;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;
using RMT_API.Repositories;
using System.Linq;

namespace RMT_API.Services
{
	public class DepartmentsService(IGenericRepository<DepartmentMaster> _repository, IMapper _mapper) : IDepartmentsService
	{
		public async Task AddDepartmentAsync(BaseDto department)
		{
			await _repository.AddAsync(_mapper.Map<DepartmentMaster>(department));
		}

		public async Task DeleteDepartmentAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<BaseDto>> GetAllDepartmentsAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await _repository.GetAllAsync(query => query.Where(p => p.Name!.Contains(searchText))
			.Skip(pageNumber * pageSize)
			.Take(pageSize));
			return _mapper.Map<IEnumerable<BaseDto>>(response);
		}

		public async Task<BaseDto> GetDepartmentByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<BaseDto>(response);
		}

		public async Task UpdateDepartmentAsync(BaseDto department)
		{
			await _repository.UpdateAsync(_mapper.Map<DepartmentMaster>(department));
		}

		public async Task ChangeStatusDepartmentAsync(BaseDto department)
		{
			await _repository.ChangeStatusAsync(department.ID, department.IsActive);
		}
	}

}
