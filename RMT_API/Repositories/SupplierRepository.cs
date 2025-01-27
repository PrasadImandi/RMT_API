using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class SupplierRepository(IGenericRepository<Supplier> _repository) : ISupplierRepository
	{
		public async Task ChangeStatusSupplier(Supplier supplier)
		{
			// Fetch the existing supplier by ID
			var existingSupplier = await _repository.GetByIdAsync(supplier.SupplierID, "SupplierID");

			if (existingSupplier != null)
			{
				// Update the status
				existingSupplier.IsActive = supplier.IsActive;

				// Save the changes
				await _repository.UpdateAsync(existingSupplier);
			}
		}
	}
}
