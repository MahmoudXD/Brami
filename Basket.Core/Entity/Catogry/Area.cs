using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class Area
	{
		public int Id { get; set; }
		public string ArabicName { get; set; }
		public string EnglishName { get; set; }

		public int CityId { get; set; }
		public City City { get; set; }

		// Other properties and relationships
	}
}
