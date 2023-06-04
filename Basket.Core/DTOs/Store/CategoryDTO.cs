using Basket.Core.Entity.Catogry;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.DTOs.Store
{
	public class CategoryDTO
	{
		[Required, MaxLength(150)]
		public string? NameAr { get; set; }

		[Required, MaxLength(150)]
		public string? NameEn { get; set; }

		[Required, MaxLength(250)]
		public string? DescriptionAr { get; set; }

		[Required, MaxLength(250)]
		public string? DescriptionEn { get; set; }

		[Required]
		public string? Image { get; set; }
		public int? MainCatogryId { get; set; }
		public int? StoreId { get; set; }
	}
}
