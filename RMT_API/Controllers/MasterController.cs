﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MasterController(IMasterService _service) : ControllerBase
	{
		[HttpGet("{type}")]
		public async Task<IActionResult> GetAllMaster(string type)
		{
			var Master = await _service.GetAllMastersAsync(type);
			return Ok(Master);
		}

		[HttpPost("{type}")]
		public async Task<IActionResult> CreateMaster(string type,[FromBody] BaseDto Master)
		{
			if (Master == null)
			{
				return BadRequest("Master data is null.");
			}

			await _service.AddMasterAsync(type, Master);

			return Created();
		}

		[HttpPut("{type}/{id}")]
		public async Task<IActionResult> UpdateMaster(string type, int id, [FromBody] BaseDto Master)
		{
			if (id != Master.ID)
			{
				return BadRequest("Master ID mismatch.");
			}

			await _service.UpdateMasterAsync(type, Master);

			return NoContent();
		}

		[HttpDelete("{type}/{id}")]
		public async Task<IActionResult> DeleteMaster(string type, int id)
		{
			await _service.DeleteMasterAsync(type, id);

			return NoContent();
		}

		[HttpPatch("{type}")]
		public async Task<IActionResult> ChangeStatusMaster(string type, [FromBody] BaseDto Master)
		{
			await _service.ChangeStatusMasterAsync(type, Master);

			return NoContent();
		}

	}
}
