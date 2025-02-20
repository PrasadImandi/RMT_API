using Microsoft.AspNetCore.Mvc;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DashboardController(IDashboardDetailsService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllAccessType()
		{
			var details = await _service.GetDashboardDetailsAsync();
			return Ok(details);
		}
	}
}
