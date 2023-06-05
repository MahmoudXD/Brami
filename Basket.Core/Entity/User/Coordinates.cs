using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.User
{
	public class Coordinates
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal latatiude { get; set; }
		public decimal longatiude { get; set; }
	}
}
