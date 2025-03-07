using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ClientService(IGenericRepository<Client> repository, IMapper mapper) : IClientService
	{

		public async Task<IEnumerable<ClientDto>> GetAllClientsAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await repository.GetAllAsync(query => query
																	  .Include(p => p.RegionMater)
																	  .Include(p => p.StateMaster)
																	  .Include(p => p.SPOC)
																	  .Include(p => p.LocationMaster)
																	  .Include(p => p.PincodeMaster)
																	  .Skip(pageNumber * pageSize)
																	  .Take(pageSize));
			return mapper.Map<IEnumerable<ClientDto>>(response);
		}

		public async Task<ClientDto> GetClientByIdAsync(int id)
		{
			var response = await repository.GetByIdAsync(id);
			return mapper.Map<ClientDto>(response);
		}

		public async Task AddClientAsync(ClientDto client)
		{
			await repository.AddAsync(mapper.Map<Client>(client));
		}

		public async Task DeleteClientAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task UpdateClientAsync(ClientDto client)
		{
			await repository.UpdateAsync(mapper.Map<Client>(client));
		}

		public async Task ChangeStatusClientAsync(ClientDto client)
		{
			await repository.ChangeStatusAsync(client.ID, client.IsActive);
		}
	}
}
