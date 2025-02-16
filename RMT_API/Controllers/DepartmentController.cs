using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController(IDepartmentsService service) : ControllerBase
	{
		private readonly IDepartmentsService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllDepartments()
		{
			var departments = await _service.GetAllDepartmentsAsync();
			return Ok(departments);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDepartment(int id)
		{
			var department = await _service.GetDepartmentByIdAsync(id);
			if (department == null)
			{
				return NotFound();
			}

			return Ok(department);
		}

		[HttpPost]
		public async Task<IActionResult> CreateDepartment([FromBody] BaseDto department)
		{
			if (department == null)
			{
				return BadRequest("Department data is null.");
			}

			await _service.AddDepartmentAsync(department);

			return CreatedAtAction(nameof(GetDepartment), new { id = department.ID }, department);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateDepartment(int id, [FromBody] BaseDto department)
		{
			if (id != department.ID)
			{
				return BadRequest("Department ID mismatch.");
			}

			await _service.UpdateDepartmentAsync(department);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDepartment(int id)
		{
			await _service.DeleteDepartmentAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusDepartment([FromBody] BaseDto department)
		{
			await _service.ChangeStatusDepartmentAsync(department);

			return NoContent();
		}
	}

}
