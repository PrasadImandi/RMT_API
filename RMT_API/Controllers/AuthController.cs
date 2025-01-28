using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RMT_API.DTOs;
using RMT_API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(IConfiguration _configuration, IUsersService _userService) : ControllerBase
	{
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UsersDto model)
		{
			var user = await _userService.GetUserByNameAsync(model.Name!);

			if (user == null)
			{
				return Unauthorized("Invalid username");
			}

			var claims = new[]{
			new Claim(ClaimTypes.Name, user.Name!),
			new Claim(ClaimTypes.Role, user.AccessTypeID.ToString()!)
				};
			var keybytes = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
			if (keybytes.Length < 32)
			{
				Array.Resize(ref keybytes, 32);
			}
			var key = new SymmetricSecurityKey(keybytes);
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddHours(1),
				signingCredentials: creds);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

			return Ok(new { Token = tokenString });
		}
	}
}
