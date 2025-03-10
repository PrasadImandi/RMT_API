using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ClientController(IClientService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllClientsAsync(string searchText="", int pageNumber = 0, int pageSize = 10)
		{
			var clients = await _service.GetAllClientsAsync(searchText, pageNumber, pageSize);
			return Ok(clients);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetClientAsync(int id)
		{
			var client = await _service.GetClientByIdAsync(id);
			if (client == null)
			{
				return NotFound();
			}

			return Ok(client);
		}

		[HttpPost]
		public async Task<IActionResult> CreateClientAsync([FromBody] ClientDto client)
		{
			if (client == null)
			{
				return BadRequest("Client data is null.");
			}

			await _service.AddClientAsync(client);

			return CreatedAtAction(nameof(GetClientAsync), new { id = client.ID }, client);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateClientAsync(int id, [FromBody] ClientDto client)
		{
			if (id != client.ID)
			{
				return BadRequest("Client ID mismatch.");
			}

			await _service.UpdateClientAsync(client);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteClientAsync(int id)
		{
			await _service.DeleteClientAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusClientAsync([FromBody] ClientDto client)
		{
			await _service.ChangeStatusClientAsync(client);

			return NoContent();
		}
	}
}
