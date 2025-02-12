using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientController(IClientService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllClients()
		{
			var clients = await _service.GetAllClientsAsync();
			return Ok(clients);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetClient(int id)
		{
			var client = await _service.GetClientByIdAsync(id);
			if (client == null)
			{
				return NotFound();
			}

			return Ok(client);
		}

		[HttpPost]
		public async Task<IActionResult> CreateClient([FromBody] ClientDto client)
		{
			if (client == null)
			{
				return BadRequest("Client data is null.");
			}

			await _service.AddClientAsync(client);

			return CreatedAtAction(nameof(GetClient), new { id = client.ID }, client);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientDto client)
		{
			if (id != client.ID)
			{
				return BadRequest("Client ID mismatch.");
			}

			await _service.UpdateClientAsync(client);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteClient(int id)
		{
			await _service.DeleteClientAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusClient([FromBody] ClientDto client)
		{
			await _service.ChangeStatusClientAsync(client);

			return NoContent();
		}
	}
}
