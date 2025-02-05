using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using System.Linq.Expressions;
using System.Reflection;



namespace RMT_API.Repositories
{
	public class GenericRepository<T>(ApplicationDBContext _context) : IGenericRepository<T> where T : class
	{
		private readonly DbSet<T> _dbSet = _context.Set<T>();

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<List<T>> GetAllWithChildrenAsync(params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = (IQueryable<T>)_dbSet;

			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return await query.ToListAsync();
		}

		public async Task<T> GetByIDWithChildrenAsync(Expression<Func<T, bool>> whereConditions, Func<IQueryable<T>, IQueryable<T>> includeChildren)
		{
			IQueryable<T> query = (IQueryable<T>)_dbSet;

			if (whereConditions != null)
				query = (IQueryable<T>)query.Where(whereConditions);

			query = includeChildren(query);

			return await query.FirstOrDefaultAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			var response = await _dbSet.FindAsync(id);

			return response!;
		}

		public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
		{
			var response = await _dbSet.Where(predicate).ToListAsync();
			return response;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<T> GetByIdAsNoTrackingAsync(int id)
		{
			var entity = await _dbSet.AsNoTracking()
									  .FirstOrDefaultAsync(e => EF.Property<int>(e, "ID") == id);
			return entity!;
		}

		public async Task ChangeStatusAsync(int id, bool? status)
		{
			var entity = await GetByIdAsNoTrackingAsync(id) ?? throw new Exception("Entity not found");
			var property = typeof(T).GetProperty("IsActive", BindingFlags.Public | BindingFlags.Instance);
			if (property != null && property.CanWrite)
			{
				try
				{
					property.SetValue(entity, status);

				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
			else
			{
				throw new Exception($"Column 'IsActive' not found or not writable");
			}

			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllActiveAsync()
		{
			var entities = await _dbSet.AsNoTracking()
									  .Where(e => EF.Property<bool>(e, "IsActive") == true).ToListAsync();

			return entities;
		}
	}
}