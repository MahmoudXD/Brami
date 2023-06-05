using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class AnounanceItem
	{
		public int Id { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }

		public int AnounanceId { get; set; }
		public Anounance Anounance { get; set; }
	}
}
