using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(IUsersService _service) : ControllerBase
	{

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await _service.GetAllUsersWithChildAsync();
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
			// Hasing password with BCrypt
			user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
			await _service.AddUserAsync(user);

			return Created(nameof(GetUser), new { id = user.ID });
		}

		[HttpPut()]
		public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
		{
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
		public async Task<IActionResult> ChangeStatusUser([FromBody] ResourceIdentifierDto user)
		{
			await _service.ChangeStatusUserAsync(user);
			return NoContent();
		}

		[HttpPatch("changepassword")]
		public async Task<IActionResult> ChangePassword([FromBody] ResetPasswordDto resetPassword)
		{

			var user = await _service.GetUserByNameAsync(resetPassword.UserName!);

			if (user == null || string.IsNullOrEmpty(user.Password))
			{
				return Unauthorized("Invalid Username & Password");
			}

			if (!BCrypt.Net.BCrypt.Verify(resetPassword.OldPassword, user.Password))
			{
				return Unauthorized("Invalid Password");
			}

			await _service.ChangePasswordAsync(resetPassword.NewPassword!, resetPassword.UserName!);
			return NoContent();
		}
	}
}
