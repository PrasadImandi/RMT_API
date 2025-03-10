using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class HelperController(IHelperService _service) : ControllerBase
	{
		[HttpGet("leftNavItems/{id}")]
		public async Task<IActionResult> GetLeftMenuItemsByRoleID(int id)
		{
			var navItems = await _service.GetLeftNavItemsByRoleIdAsync(id);
			return Ok(navItems);
		}
	}
}
