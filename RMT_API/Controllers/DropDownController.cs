using Microsoft.AspNetCore.Mvc;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DropDownController(ISelectValuesService _service) : ControllerBase
	{

		#region GetRequests
		[HttpGet("clients")]
		public async Task<IActionResult> GetClients()
		{
			var clients = await _service.ClientIDNameListAsync();
			return Ok(clients);
		}

		[HttpGet("states")]
		public async Task<IActionResult> GetStates()
		{
			var states = await _service.StateIDNameListAsync();
			return Ok(states);
		}

		[HttpGet("locations")]
		public async Task<IActionResult> GetLocations()
		{
			var states = await _service.LocationIDNameListAsync();
			return Ok(states);
		}

		[HttpGet("pincodes")]
		public async Task<IActionResult> GetPincodes()
		{
			var pincodes = await _service.PinCodeIDNameListAsync();
			return Ok(pincodes);
		}

		[HttpGet("regions")]
		public async Task<IActionResult> GetRegions()
		{
			var regions = await _service.RegionIDNameListAsync();
			return Ok(regions);
		}

		[HttpGet("spocs")]
		public async Task<IActionResult> GetSPOCs()
		{
			var spocs = await _service.SPOCIDNameListAsync();
			return Ok(spocs);
		}

		[HttpGet("domain")]
		public async Task<IActionResult> GetDomains()
		{
			var spocs = await _service.DomainIDNameListAsync();
			return Ok(spocs);
		}

		[HttpGet("domainroles")]
		public async Task<IActionResult> GetDomainRoles()
		{
			var spocs = await _service.DomainRoleIDNameListAsync();
			return Ok(spocs);
		}

		[HttpGet("domainroles/{domainId}")]
		public async Task<IActionResult> GetDomainRoles(int domainId)
		{
			var spocs = await _service.DomainRoleIDNameListByDomainIdAsync(domainId);
			return Ok(spocs);
		}

		[HttpGet("domainlevels")]
		public async Task<IActionResult> GetDomainLevels()
		{
			var spocs = await _service.DomainLevelIDNameListAsync();
			return Ok(spocs);
		}
		#endregion GetRequests

	}
}
