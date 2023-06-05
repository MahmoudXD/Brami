using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class FavouriteStoreList
	{
		public int Id { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }

		public int FavouriteStoreId { get; set; }
		public FavouriteStore FavouriteStore { get; set; }
	}
}
