using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceOnboardingController(IResourceOnboardingsService service) : ControllerBase
	{
		private readonly IResourceOnboardingsService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllResourceOnboardings()
		{
			var resourceOnboardings = await _service.GetAllResourceOnboardingsAsync();
			return Ok(resourceOnboardings);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetResourceOnboarding(int id)
		{
			var resourceOnboarding = await _service.GetResourceOnboardingByIdAsync(id);
			if (resourceOnboarding == null)
			{
				return NotFound();
			}

			return Ok(resourceOnboarding);
		}

		[HttpPost]
		public async Task<IActionResult> CreateResourceOnboarding([FromBody] ResourceOnboardingDto resourceOnboarding)
		{
			if (resourceOnboarding == null)
			{
				return BadRequest("ResourceOnboarding data is null.");
			}

			await _service.AddResourceOnboardingAsync(resourceOnboarding);

			return CreatedAtAction(nameof(GetResourceOnboarding), new { id = resourceOnboarding.ID }, resourceOnboarding);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateResourceOnboarding(int id, [FromBody] ResourceOnboardingDto resourceOnboarding)
		{
			if (id != resourceOnboarding.ID)
			{
				return BadRequest("ResourceOnboarding ID mismatch.");
			}

			await _service.UpdateResourceOnboardingAsync(resourceOnboarding);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteResourceOnboarding(int id)
		{
			await _service.DeleteResourceOnboardingAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusResourceOnboarding([FromBody] ResourceOnboardingDto resourceOnboarding)
		{
			await _service.ChangeStatusResourceOnboardingAsync(resourceOnboarding);

			return NoContent();
		}
	}

}
