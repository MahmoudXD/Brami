using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class AttributeTitle
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class AttributeValue
	{
		public int Id { get; set; }
		public string Value { get; set; }

		public int AttributeId { get; set; }
		public AttributeTitle Attribute { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
