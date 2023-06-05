using Basket.Core.Entity.Catogry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.User
{
	public class Address
	{
		public int Id { get; set; }
		public int Flat { get; set; }
		public int Floor { get; set; }
		public int Block { get; set; }
		public string Street { get; set; }
		public int CityId { get; set; }
		public City City { get; set; }
		public int AreaId { get; set; }
		public Area Area { get; set; }
		public int CoordinatesId { get; set; }
		public Coordinates Coordinates { get; set; }

		public int UserId { get; set; }
		public ApplicationUser User { get; set; }
	}
}
