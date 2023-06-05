using Basket.Core.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class FavouriteStore
	{
		public int Id { get; set; }

		public ICollection<FavouriteStoreList> FavouriteStoreList { get; set; }
		public string UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
