using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceLifecycleController(IResourceLifecyclesService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllResourceLifecycles()
		{
			var resourceLifecycles = await _service.GetAllResourceLifecyclesAsync();
			return Ok(resourceLifecycles);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetResourceLifecycle(int id)
		{
			var resourceLifecycle = await _service.GetResourceLifecycleByIdAsync(id);
			if (resourceLifecycle == null)
			{
				return NotFound();
			}

			return Ok(resourceLifecycle);
		}

		[HttpPost]
		public async Task<IActionResult> CreateResourceLifecycle([FromBody] ResourceLifeCycleDto resourceLifecycle)
		{
			if (resourceLifecycle == null)
			{
				return BadRequest("ResourceLifecycle data is null.");
			}

			await _service.AddResourceLifecycleAsync(resourceLifecycle);

			return CreatedAtAction(nameof(GetResourceLifecycle), new { id = resourceLifecycle.ID }, resourceLifecycle);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateResourceLifecycle(int id, [FromBody] ResourceLifeCycleDto resourceLifecycle)
		{
			if (id != resourceLifecycle.ID)
			{
				return BadRequest("ResourceLifecycle ID mismatch.");
			}

			await _service.UpdateResourceLifecycleAsync(resourceLifecycle);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteResourceLifecycle(int id)
		{
			await _service.DeleteResourceLifecycleAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusResourceLifecycle([FromBody] ResourceLifeCycleDto resourceLifecycle)
		{
			await _service.ChangeStatusResourceLifecycleAsync(resourceLifecycle);

			return NoContent();
		}
	}

}
