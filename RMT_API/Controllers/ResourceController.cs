using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceController(IResourcesService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllResources()
		{
			var resources = await _service.GetAllResourcesAsync();
			return Ok(resources);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetResource(int id)
		{
			var resource = await _service.GetResourceByIdAsync(id);
			if (resource == null)
			{
				return NotFound();
			}

			return Ok(resource);
		}

		[HttpGet("resources/{projectId}")]
		public async Task<IActionResult> GetResourcesByProjectId(int projectId)
		{
			var resource = await _service.GetResourcesByProjectId(projectId);
			if (resource == null)
			{
				return NotFound();
			}

			return Ok(resource);
		}

		[HttpPost]
		public async Task<IActionResult> CreateResource([FromBody] ResourceDto resource)
		{
			if (resource == null)
			{
				return BadRequest("Resource data is null.");
			}

			await _service.AddResourceAsync(resource);

			return CreatedAtAction(nameof(GetResource), new { id = resource.ID }, resource);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateResource(int id, [FromBody] ResourceDto resource)
		{
			if (id != resource.ID)
			{
				return BadRequest("Resource ID mismatch.");
			}

			await _service.UpdateResourceAsync(resource);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteResource(int id)
		{
			await _service.DeleteResourceAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusResource([FromBody] ResourceDto resource)
		{
			await _service.ChangeStatusResourceAsync(resource);

			return NoContent();
		}
	}

}
