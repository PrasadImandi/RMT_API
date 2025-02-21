using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceInformationController(IResourceInformationService _service) : ControllerBase
	{
		[HttpGet("{id}")]
		public async Task<IActionResult> GetResourceInformationById(int id)
		{
			var resourceInfo = await _service.GetResourceInformationByIdAsync(id);
			
			if (resourceInfo == null)
			{
				return NotFound();
			}

			return Ok(resourceInfo);
		}

		[HttpPost]
		public async Task<IActionResult> CreateResourceInfo([FromBody] ResourceInformationDto resourceInfo)
		{
			if (resourceInfo == null)
			{
				return BadRequest("ResourceInformation data is null.");
			}

			await _service.AddResourceInformationAsync(resourceInfo);

			return CreatedAtAction(nameof(GetResourceInformationById), new { id = resourceInfo.ID }, resourceInfo);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateResourceInformation(int id, [FromBody] ResourceInformationDto resourceInfo)
		{
			if (id != resourceInfo.ID)
			{
				return BadRequest("Client ID mismatch.");
			}

			await _service.UpdateResourceInfoAsync(resourceInfo);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteResourceInformation(int id)
		{
			await _service.DeleteResourceInformationAsync(id);

			return NoContent();
		}

		[HttpDelete("academic/{id}")]
		public async Task<IActionResult> DeleteAcademicDetails(int id)
		{
			await _service.DeleteAcademicDetailsAsync(id);

			return NoContent();
		}

		[HttpDelete("certification/{id}")]
		public async Task<IActionResult> DeleteCertificationDetails(int id)
		{
			await _service.DeleteCertificationDetailsAsync(id);

			return NoContent();
		}

		[HttpDelete("bgv/{id}")]
		public async Task<IActionResult> DeleteBGVDocs(int id)
		{
			await _service.DeleteBGVDocsAsync(id);

			return NoContent();
		}

		[HttpGet("user/{userId}")]
		public async Task<IActionResult> GetResourceByUserID(int userId)
		{
			var resource = await _service.GetResourceByUserIdAsync(userId);
			if (resource == null)
			{
				return NotFound();
			}

			return Ok(resource);
		}
	}
}
