using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TimesheetController(ITimesheetsService service) : ControllerBase
	{
		private readonly ITimesheetsService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllTimesheets()
		{
			var timesheets = await _service.GetAllTimesheetsAsync();
			return Ok(timesheets);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetTimesheet(int id)
		{
			var timesheet = await _service.GetTimesheetByIdAsync(id);
			if (timesheet == null)
			{
				return NotFound();
			}

			return Ok(timesheet);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTimesheet([FromBody] TimesheetDto timesheet)
		{
			if (timesheet == null)
			{
				return BadRequest("Timesheet data is null.");
			}

			await _service.AddTimesheetAsync(timesheet);

			return CreatedAtAction(nameof(GetTimesheet), new { id = timesheet.ID }, timesheet);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTimesheet(int id, [FromBody] TimesheetDto timesheet)
		{
			if (id != timesheet.ID)
			{
				return BadRequest("Timesheet ID mismatch.");
			}

			await _service.UpdateTimesheetAsync(timesheet);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTimesheet(int id)
		{
			await _service.DeleteTimesheetAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusTimesheet([FromBody] TimesheetDto timesheet)
		{
			await _service.ChangeStatusTimesheetAsync(timesheet);

			return NoContent();
		}
	}

}
