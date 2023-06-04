using Basket.Core.Entity.Catogry;
using Basket.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core
{
    public interface IUnitOfWork: IDisposable
	{
		IBaseRepository<MainCatogry> mainCatogry { get; }
		IBaseRepository<Store> store { get; }
		IBaseRepository<Category> category { get; }


		int Complete();
	}
}
