﻿using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PublicHolidaysController(IPublicHolidaysService service) : ControllerBase
	{
		private readonly IPublicHolidaysService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllPublicHolidays()
		{
			var publicHolidays = await _service.GetAllPublicHolidaysAsync();
			return Ok(publicHolidays);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPublicHoliday(int id)
		{
			var publicHoliday = await _service.GetPublicHolidayByIdAsync(id);
			if (publicHoliday == null)
			{
				return NotFound();
			}

			return Ok(publicHoliday);
		}

		[HttpPost]
		public async Task<IActionResult> CreatePublicHoliday([FromBody] PublicHolidayDto publicHoliday)
		{
			if (publicHoliday == null)
			{
				return BadRequest("Public holiday data is null.");
			}

			await _service.AddPublicHolidayAsync(publicHoliday);

			return CreatedAtAction(nameof(GetPublicHoliday), new { id = publicHoliday.PHID }, publicHoliday);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePublicHoliday(int id, [FromBody] PublicHolidayDto publicHoliday)
		{
			if (id != publicHoliday.PHID)
			{
				return BadRequest("Public Holiday ID mismatch.");
			}

			await _service.UpdatePublicHolidayAsync(publicHoliday);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePublicHoliday(int id)
		{
			await _service.DeletePublicHolidayAsync(id);

			return NoContent();
		}
	}
}
