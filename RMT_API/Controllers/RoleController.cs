using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController(IRolesService service) : ControllerBase
	{
		private readonly IRolesService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllRoles()
		{
			var roles = await _service.GetAllRolesAsync();
			return Ok(roles);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetRole(int id)
		{
			var role = await _service.GetRoleByIdAsync(id);
			if (role == null)
			{
				return NotFound();
			}

			return Ok(role);
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole([FromBody] RoleDto role)
		{
			if (role == null)
			{
				return BadRequest("Role data is null.");
			}

			await _service.AddRoleAsync(role);

			return CreatedAtAction(nameof(GetRole), new { id = role.ID }, role);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDto role)
		{
			if (id != role.ID)
			{
				return BadRequest("Role ID mismatch.");
			}

			await _service.UpdateRoleAsync(role);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			await _service.DeleteRoleAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusRole([FromBody] RoleDto role)
		{
			await _service.ChangeStatusRoleAsync(role);

			return NoContent();
		}
	}

}
