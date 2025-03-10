using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class TimesheetController(ITimesheetsService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllTimesheets(string searchText = "", int pageNumber = 0, int pageSize = 10)
		{
			var timesheets = await _service.GetAllTimesheetsAsync(searchText, pageNumber, pageSize);
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

		[HttpPost("search-timesheets")]
		public async Task<IActionResult> GetTimesheetsByResourceId(int id)
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


		[HttpPatch("approval")]
		public async Task<IActionResult> ApproveTimesheet([FromBody] TimesheetDto timesheet)
		{
			await _service.ApproveTimesheetAsync(timesheet);

			return NoContent();
		}


		[HttpGet("timesheet/{resourceId}/{startOfWeek}")]
		public async Task<IActionResult> GetWeekTimesheetByStartDate(int resourceId, DateTime startOfWeek)
		{
			var timesheet = await _service.GetWeekTimesheetByStartDate(resourceId, startOfWeek);
			if (timesheet == null)
			{
				return NotFound();
			}

			return Ok(timesheet);
		}
	}

}
