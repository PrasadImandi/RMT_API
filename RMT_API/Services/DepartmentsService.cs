using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class DepartmentsService(IGenericRepository<Department> _repository, IMapper _mapper) : IDepartmentsService
	{
		public async Task AddDepartmentAsync(DepartmentDto department)
		{
			await _repository.AddAsync(_mapper.Map<Department>(department));
		}

		public async Task DeleteDepartmentAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
		{
			var response = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<DepartmentDto>>(response);
		}

		public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<DepartmentDto>(response);
		}

		public async Task UpdateDepartmentAsync(DepartmentDto department)
		{
			await _repository.UpdateAsync(_mapper.Map<Department>(department));
		}

		public async Task ChangeStatusDepartmentAsync(DepartmentDto department)
		{
			await _repository.ChangeStatusAsync(department.ID, department.IsActive);
		}
	}

}
