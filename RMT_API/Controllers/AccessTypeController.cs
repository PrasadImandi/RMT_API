using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccessTypeController(IAccessTypeService service) : ControllerBase
	{
		private readonly IAccessTypeService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllAccessType()
		{
			var AccessType = await _service.GetAllAccessTypesAsync();
			return Ok(AccessType);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAccessType(int id)
		{
			var AccessType = await _service.GetAccessTypeByIdAsync(id);
			if (AccessType == null)
			{
				return NotFound();
			}

			return Ok(AccessType);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAccessType([FromBody] AccessTypeMasterDto AccessType)
		{
			if (AccessType == null)
			{
				return BadRequest("AccessType data is null.");
			}

			await _service.AddAccessTypeAsync(AccessType);

			return CreatedAtAction(nameof(GetAccessType), new { id = AccessType.ID }, AccessType);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAccessType(int id, [FromBody] AccessTypeMasterDto AccessType)
		{
			if (id != AccessType.ID)
			{
				return BadRequest("AccessType ID mismatch.");
			}

			await _service.UpdateAccessTypeAsync(AccessType);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAccessType(int id)
		{
			await _service.DeleteAccessTypeAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusAccessType([FromBody] AccessTypeMasterDto AccessType)
		{
			await _service.ChangeStatusAccessTypeAsync(AccessType);

			return NoContent();
		}
	}
}