using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Basket.Core.Entity.Catogry
{
	public class Product
	{
		public int Id { get; set; }
		[Required, MaxLength(150)]
		public string NameAr { get; set; }

		[Required, MaxLength(150)]
		public string NameEn { get; set; }

		[Required, MaxLength(250)]
		public string? DescriptionAr { get; set; }

		[Required, MaxLength(250)]
		public string? DescriptionEn { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public ICollection<Image> Images { get; set; }
		public ICollection<Offer> Offers { get; set; }
		public ICollection<AttributeValue> AttributeValues { get; set; }
	}
}
