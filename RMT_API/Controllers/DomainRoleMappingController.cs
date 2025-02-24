using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DomainRoleMappingController(IDomainRoleMappingService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllDomainRoleMapping()
		{
			var DomainRoleMapping = await _service.GetAllDomainRoleMappingsAsync();
			return Ok(DomainRoleMapping);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDomainRoleMapping(int id)
		{
			var DomainRoleMapping = await _service.GetDomainRoleMappingByIdAsync(id);
			if (DomainRoleMapping == null)
			{
				return NotFound();
			}

			return Ok(DomainRoleMapping);
		}

		[HttpPost]
		public async Task<IActionResult> CreateDomainRoleMapping([FromBody] DomainRoleMappingDto domainRoleMapping)
		{
			if (domainRoleMapping == null)
			{
				return BadRequest("DomainRoleMapping data is null.");
			}

			await _service.AddDomainRoleMappingAsync(domainRoleMapping);

			return CreatedAtAction(nameof(GetDomainRoleMapping), new { id = domainRoleMapping.ID }, domainRoleMapping);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateDomainRoleMapping(int id, [FromBody] DomainRoleMappingDto domainRoleMapping)
		{
			if (id != domainRoleMapping.ID)
			{
				return BadRequest("DomainRoleMapping ID mismatch.");
			}

			await _service.UpdateDomainRoleMappingAsync(domainRoleMapping);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDomainRoleMapping(int id)
		{
			await _service.DeleteDomainRoleMappingAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusDomainRoleMapping([FromBody] DomainRoleMappingDto DomainRoleMapping)
		{
			await _service.ChangeStatusDomainRoleMappingAsync(DomainRoleMapping);

			return NoContent();
		}
	}
}
