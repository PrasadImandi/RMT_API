using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class SupplierService(IGenericRepository<Supplier> _repository, IMapper _mapper) : ISupplierService
	{
		public async Task AddSupplierAsync(SupplierDto supplier)
		{
			await _repository.AddAsync(_mapper.Map<Supplier>(supplier));
		}

		public async Task DeleteSupplierAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await _repository.GetAllAsync(query => query.Include(p=>p.ContactInformation)
																	  .Where(p => p.Name!.Contains(searchText))
																	  .Skip(pageNumber * pageSize)
																	  .Take(pageSize));
			return _mapper.Map<IEnumerable<SupplierDto>>(response);
		}

		public async Task<SupplierDto> GetSupplierByIdAsync(int id)
		{
			var response = await _repository.GetSingleAsync(p => p.ID == id,
																	  query => query.Include(p => p.ContactInformation));
			return _mapper.Map<SupplierDto>(response);
		}

		public async Task UpdateSupplierAsync(SupplierDto supplier)
		{
			await _repository.UpdateAsync(_mapper.Map<Supplier>(supplier));
		}

		public async Task ChangeStatusSupplierAsync(SupplierDto supplier)
		{
			await _repository.ChangeStatusAsync(supplier.ID, supplier.IsActive);
		}
	}
}
