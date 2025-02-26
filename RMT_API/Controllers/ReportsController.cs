using Microsoft.AspNetCore.Mvc;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportsController(IReportsService _reportService
									) : ControllerBase
	{

		[HttpGet("clients")]
		public async Task<IActionResult> GetAllClients(int clientId, int projectId, int pmid, int rmid)
		{
			var clientReports = await _reportService.GetClientReportsAsync(clientId, projectId, pmid,rmid);
			return Ok(clientReports);
		}

		//[HttpGet("suppliers")]
		//public async Task<IActionResult> GetAllSuppliers()
		//{
		//	var clients = await _clientService.GetAllClientsAsync();
		//	return Ok(clients);
		//}

		//[HttpGet("supplierContactMatrix")]
		//public async Task<IActionResult> GetAllSupplierContactMatrices()
		//{
		//	var clients = await _clientService.GetAllClientsAsync();
		//	return Ok(clients);
		//}

		//[HttpGet("resources")]
		//public async Task<IActionResult> GetAllResources()
		//{
		//	var clients = await _resourceService.GetAllResourcesAsync();
		//	return Ok(clients);
		//}
	}
}
