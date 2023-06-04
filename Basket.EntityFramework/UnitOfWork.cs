using Basket.Core;
using Basket.Core.Entity.Catogry;
using Basket.Core.Interfaces;
using Basket.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public IBaseRepository<MainCatogry> mainCatogry { get; private set; }
		public IBaseRepository<Store> store { get; private set; }

		public IBaseRepository<Category> category { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			mainCatogry = new BaseRepository<MainCatogry>(_context);
			store = new BaseRepository<Store>(_context);
			category = new BaseRepository<Category>(_context);
		}

		

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
