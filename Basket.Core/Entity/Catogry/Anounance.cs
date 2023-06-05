using Basket.Core.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
	public class Anounance
	{
		public int Id { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public ICollection<AnounanceItem> AnounanceItem { get; set; }
	}
}
