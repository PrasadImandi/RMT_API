using System.Linq.Expressions;

namespace RMT_API.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> includeQuery);
		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
		Task<T> GetSingleAsync(Expression<Func<T, bool>> whereConditions, Func<IQueryable<T>, IQueryable<T>>? includeChildren = null);
		Task<T> GetByIdAsync(int id);
		Task<T> GetByIdAsNoTrackingAsync(int id);
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(int id);
		Task ChangeStatusAsync(int id, bool? status);
	}
}
