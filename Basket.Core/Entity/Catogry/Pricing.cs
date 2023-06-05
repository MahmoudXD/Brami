using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class Pricing
	{
		public decimal Price { get; set; }

		public byte Rate { get; set; }

		public int Quantity { get; set; }

		public int AttributeId { get; set; }
		public AttributeValue Attribute { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
