﻿using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceInformationController(IResourceInformationService _service) : ControllerBase
	{
		[HttpGet("{id}")]
		public async Task<IActionResult> GetRsourceInformatonById(int id)
		{
			var resouceInfo = await _service.GetRsourceInformatonByIdAsync(id);
			
			if (resouceInfo == null)
			{
				return NotFound();
			}

			return Ok(resouceInfo);
		}

		[HttpPost]
		public async Task<IActionResult> CreateResourceInfo([FromBody] ResourceInformationDto resouceInfo)
		{
			if (resouceInfo == null)
			{
				return BadRequest("ResourceInformation data is null.");
			}

			await _service.AddResourceInformationAsync(resouceInfo);

			return CreatedAtAction(nameof(GetRsourceInformatonById), new { id = resouceInfo.ID }, resouceInfo);
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
	}
}
