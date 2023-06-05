using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class City
	{
		public int Id { get; set; }
		public string ArabicName { get; set; }
		public string EnglishName { get; set; }

		// Navigation property
		public ICollection<Area> Areas { get; set; }
	}

	

}
