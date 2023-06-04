using Basket.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.Catogry
{
    public class Store : BaseModel
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? Image { get; set; }
        public string? Cover { get; set; }
        public int MainCatogryId { get; set; }
        public MainCatogry mainCatogry { get; set; }
    }
}
