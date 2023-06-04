using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.DTOs.Store
{
	public class StoreDTO
	{
		public string? NameAr { get; set; }
		public string? NameEn { get; set; }
		public string? DescriptionAr { get; set; }
		public string? DescriptionEn { get; set; }
		public string? Image { get; set; }
		public string? Cover { get; set; }
		public int? MainCatogryId {	get; set; }
	}
}
