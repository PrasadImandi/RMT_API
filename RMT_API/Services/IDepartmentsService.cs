using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;

namespace RMT_API.Services
{
	public interface IDepartmentsService
	{
		Task<IEnumerable<BaseDto>> GetAllDepartmentsAsync();
		Task<BaseDto> GetDepartmentByIdAsync(int id);
		Task AddDepartmentAsync(BaseDto department);
		Task UpdateDepartmentAsync(BaseDto department);
		Task DeleteDepartmentAsync(int id);
		Task ChangeStatusDepartmentAsync(BaseDto department);
	}
}
