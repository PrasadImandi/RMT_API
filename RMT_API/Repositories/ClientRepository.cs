using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ClientRepository(IGenericRepository<Client> repository) : IClientRepository
	{
		private readonly IGenericRepository<Client> _repository = repository;

		public async Task ChangeStatusClient(Client client)
		{
			var existingClient = await _repository.GetByIdAsync(client.ClientID, "ClientID");

			if (existingClient != null)
			{
				existingClient.IsActive = client.IsActive;

				await _repository.UpdateAsync(existingClient);
			}
		}
	}

}
