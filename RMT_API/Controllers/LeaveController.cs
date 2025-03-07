using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveController(ILeaveService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllLeaves(string searchText = "", int pageNumber = 0, int pageSize = 10)
		{
			var leaves = await _service.GetAllLeavesAsync(searchText, pageNumber, pageSize);
			return Ok(leaves);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetLeave(int id)
		{
			var leave = await _service.GetLeaveByIdAsync(id);
			if (leave == null)
			{
				return NotFound();
			}

			return Ok(leave);
		}

		[HttpPost]
		public async Task<IActionResult> CreateLeave([FromBody] LeaveDto leave)
		{
			if (leave == null)
			{
				return BadRequest("Leave data is null.");
			}

			await _service.AddLeaveAsync(leave);

			return CreatedAtAction(nameof(GetLeave), new { id = leave.ID }, leave);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateLeave(int id, [FromBody] LeaveDto leave)
		{
			if (id != leave.ID)
			{
				return BadRequest("Leave ID mismatch.");
			}

			await _service.UpdateLeaveAsync(leave);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLeave(int id)
		{
			await _service.DeleteLeaveAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusLeave([FromBody] LeaveDto leave)
		{
			await _service.ChangeStatusLeaveAsync(leave);

			return NoContent();
		}

		[HttpPatch("approval")]
		public async Task<IActionResult> ApproveLeaves([FromBody] LeaveDto leave)
		{
			await _service.ApproveLeavesAsync(leave);

			return NoContent();
		}
	}
}