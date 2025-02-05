using System.Linq.Expressions;

namespace RMT_API.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllActiveAsync();
		Task<List<T>> GetAllWithChildrenAsync(params Expression<Func<T, object>>[] includes);
		Task<T> GetByIDWithChildrenAsync(Expression<Func<T, bool>> whereConditions, Func<IQueryable<T>, IQueryable<T>> includeChildren);
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(int id);
		Task<T> GetByIdAsNoTrackingAsync(int id);
		Task ChangeStatusAsync(int id,bool? status);
	}
}
