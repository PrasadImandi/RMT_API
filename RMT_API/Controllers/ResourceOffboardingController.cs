﻿using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceOffboardingController(IResourceOffboardingsService service) : ControllerBase
	{
		private readonly IResourceOffboardingsService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllResourceOffboardings()
		{
			var resourceOffboardings = await _service.GetAllResourceOffboardingsAsync();
			return Ok(resourceOffboardings);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetResourceOffboarding(int id)
		{
			var resourceOffboarding = await _service.GetResourceOffboardingByIdAsync(id);
			if (resourceOffboarding == null)
			{
				return NotFound();
			}

			return Ok(resourceOffboarding);
		}

		[HttpPost]
		public async Task<IActionResult> CreateResourceOffboarding([FromBody] ResourceOffboardingDto resourceOffboarding)
		{
			if (resourceOffboarding == null)
			{
				return BadRequest("ResourceOffboarding data is null.");
			}

			await _service.AddResourceOffboardingAsync(resourceOffboarding);

			return CreatedAtAction(nameof(GetResourceOffboarding), new { id = resourceOffboarding.OffboardingID }, resourceOffboarding);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateResourceOffboarding(int id, [FromBody] ResourceOffboardingDto resourceOffboarding)
		{
			if (id != resourceOffboarding.OffboardingID)
			{
				return BadRequest("ResourceOffboarding ID mismatch.");
			}

			await _service.UpdateResourceOffboardingAsync(resourceOffboarding);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteResourceOffboarding(int id)
		{
			await _service.DeleteResourceOffboardingAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusResourceOffboarding([FromBody] ResourceOffboardingDto resourceOffboarding)
		{
			await _service.ChangeStatusResourceOffboardingAsync(resourceOffboarding);

			return NoContent();
		}
	}

}
