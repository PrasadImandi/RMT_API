using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(IUsersService service) : ControllerBase
	{
		private readonly IUsersService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await _service.GetAllUsersAsync();
			return Ok(users);
		}

		[HttpGet("usersByRoleID/{roleId}")]
		public async Task<IActionResult> GetUsersByRoleID(int roleId)
		{
			var users = await _service.GetUsersByRoleIdAsync(roleId);
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUser(int id)
		{
			var user = await _service.GetUserByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] UsersDto user)
		{
			if (user == null)
			{
				return BadRequest("User data is null.");
			}

			await _service.AddUserAsync(user);

			return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(int id, [FromBody] UsersDto user)
		{
			if (id != user.ID)
			{
				return BadRequest("User ID mismatch.");
			}

			await _service.UpdateUserAsync(user);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _service.DeleteUserAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusUser([FromBody] UsersDto user)
		{
			await _service.ChangeStatusUserAsync(user);

			return NoContent();
		}
	}
}
