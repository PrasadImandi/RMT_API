using Microsoft.EntityFrameworkCore;
using RMT_API.Data;

namespace RMT_API.Repositories
{
	public class RepositoryFactory(ApplicationDBContext _context) : IRepositoryFactory
	{
		public IGenericRepository<T> GetRepository<T>() where T : class 
		{
			return new GenericRepository<T>(_context); // returns IGenericRepository<Product>
		}
	}
}