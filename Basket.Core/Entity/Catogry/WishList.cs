using Basket.Core.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class WishList
	{
		public int Id { get; set; }
		public ICollection<WishListProduct> WishListProducts { get; set; }

		public string UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
