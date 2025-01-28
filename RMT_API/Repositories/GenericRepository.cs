using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RMT_API.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace RMT_API.Repositories
{
	public class GenericRepository<T>(ApplicationDBContext context) : IGenericRepository<T> where T : class
	{
		private readonly ApplicationDBContext _context = context;
		private readonly DbSet<T> _dbSet = context.Set<T>();

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			var response = await _dbSet.FindAsync(id);

			return response!;
		}

		public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
		{
			return await _dbSet.Where(predicate).ToListAsync();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
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
			var entity = GetByIdAsNoTrackingAsync(id);

			if (entity == null)
			{
				throw new Exception("Entity not found");
			}

			var property = typeof(T).GetProperty("IsActive", BindingFlags.Public | BindingFlags.Instance);
			if (property != null && property.CanWrite)
			{
				property.SetValue(entity, status);
			}
			else
			{
				throw new Exception($"Column 'IsActive' not found or not writable");
			}

			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}