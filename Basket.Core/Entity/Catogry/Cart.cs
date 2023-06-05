using Basket.Core.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class Cart
	{

		public int Id { get; set; }

		public ICollection<CartProduct> CartProducts { get; set; }
		public string UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
