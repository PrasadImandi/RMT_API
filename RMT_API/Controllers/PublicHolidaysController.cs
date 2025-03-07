using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PublicHolidaysController(IPublicHolidaysService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllPublicHolidays(string searchText = "", int pageNumber = 0, int pageSize = 10)
		{
			var publicHolidays = await _service.GetAllPublicHolidaysAsync(searchText, pageNumber, pageSize);
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

			return CreatedAtAction(nameof(GetPublicHoliday), new { id = publicHoliday.ID }, publicHoliday);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePublicHoliday(int id, [FromBody] PublicHolidayDto publicHoliday)
		{
			if (id != publicHoliday.ID)
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
