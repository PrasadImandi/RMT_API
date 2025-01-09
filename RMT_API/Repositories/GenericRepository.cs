﻿using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using System.Linq.Expressions;

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

		public async Task<T> GetByIdAsync(int id, string idColumnName)
		{
			var entity = await _dbSet.AsNoTracking()
									  .FirstOrDefaultAsync(e => EF.Property<int>(e, idColumnName) == id);
			return entity!;
		}
	}
}