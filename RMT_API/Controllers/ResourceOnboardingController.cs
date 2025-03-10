using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ResourceOnboardingController(IResourceOnboardingsService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllResourceOnboardings(string searchText = "", int pageNumber = 0, int pageSize = 10)
		{
			var resourceOnboardings = await _service.GetAllResourceOnboardingsAsync(searchText, pageNumber, pageSize);
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

		[HttpPatch("approval")]
		public async Task<IActionResult> ApproveOnboarding([FromBody] ResourceOnboardingDto resourceOnboarding)
		{
			await _service.ApproveOnboardingAsync(resourceOnboarding);

			return NoContent();
		}
	}

}
