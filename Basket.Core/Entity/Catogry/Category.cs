using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Basket.Core.Entity.Base;

namespace Basket.Core.Entity.Catogry
{
	public class Category: BaseModel
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
		public string? Image { get; set; }
		public int MainCatogryId { get; set; }

		[ForeignKey(nameof(MainCatogryId))]

		public virtual MainCatogry? MainCatogry { get; set; }

		public int StoreId { get; set; }

		[ForeignKey(nameof(StoreId))]
		public virtual Store? Store { get; set; }
	}
}
