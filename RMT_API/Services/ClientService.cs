using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class ClientService(IGenericRepository<Client> repository, IMapper mapper) : IClientService
	{
		public async Task AddClientAsync(ClientDto client)
		{
			await repository.AddAsync(mapper.Map<Client>(client));
		}

		public async Task DeleteClientAsync(int id)
		{
			await repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ClientDto>> GetAllClientsAsync()
		{
			var response = await repository.GetAllAsync();
			return mapper.Map<IEnumerable<ClientDto>>(response);
		}

		public async Task<ClientDto> GetClientByIdAsync(int id)
		{
			var response = await repository.GetByIdAsync(id);
			return mapper.Map<ClientDto>(response);
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
