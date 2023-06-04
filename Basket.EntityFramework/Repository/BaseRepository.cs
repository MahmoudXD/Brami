using Basket.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.EntityFramework.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected ApplicationDbContext _context;

		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<T> GetById(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAll(string[] includes = null)
		{
			IQueryable<T> query = _context.Set<T>();

			if (includes != null)
				foreach (var include in includes)
					query = query.Include(include);

			return await query.ToListAsync();
		}

		public async Task<T> AddOne(T entity)
		{


			_context.Set<T>().Add(entity);
			return entity;
		}

		public async Task<T> Update(T entity)
		{
			_context.Set<T>().Update(entity);
			return entity;
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}
	}
}
