using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Interfaces
{
	public interface IBaseRepository<T> where T : class
	{
		Task<T> GetById(int id);
		Task<IEnumerable<T>> GetAll(string[] includes = null);

		Task<T> AddOne(T entity);

		Task<T> Update(T entity);
		void Delete(T entity);
	}
}
