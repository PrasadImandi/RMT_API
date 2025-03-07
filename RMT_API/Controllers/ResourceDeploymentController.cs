using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceDeploymentController(IResourceDeploymentsService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllResourceDeployments(string searchText="", int pageNumber = 0, int pageSize = 10)
		{
			var resourceDeployments = await _service.GetAllResourceDeploymentsAsync(searchText, pageNumber, pageSize);
			return Ok(resourceDeployments);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetResourceDeployment(int id)
		{
			var resourceDeployment = await _service.GetResourceDeploymentByIdAsync(id);
			if (resourceDeployment == null)
			{
				return NotFound();
			}

			return Ok(resourceDeployment);
		}

		[HttpPost]
		public async Task<IActionResult> CreateResourceDeployment([FromBody] ResourceDeploymentDto resourceDeployment)
		{
			if (resourceDeployment == null)
			{
				return BadRequest("ResourceDeployment data is null.");
			}

			await _service.AddResourceDeploymentAsync(resourceDeployment);

			return CreatedAtAction(nameof(GetResourceDeployment), new { id = resourceDeployment.ID }, resourceDeployment);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateResourceDeployment(int id, [FromBody] ResourceDeploymentDto resourceDeployment)
		{
			if (id != resourceDeployment.ID)
			{
				return BadRequest("ResourceDeployment ID mismatch.");
			}

			await _service.UpdateResourceDeploymentAsync(resourceDeployment);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteResourceDeployment(int id)
		{
			await _service.DeleteResourceDeploymentAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusResourceDeployment([FromBody] ResourceDeploymentDto deployment)
		{
			await _service.ChangeStatusResourceDeploymentAsync(deployment);

			return NoContent();
		}
	}
}
