using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Common;

namespace MBIN.Entity.Product
{
    public class ProductCategory : BaseEntity
    {
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string UrlName { get; set; }
        public string ImageName { get; set; }

        #region Relations

        public ProductCategory Parent { get; set; }
        public ICollection<ProductSelectedCategories> ProductSelectedCategories { get; set; }

        #endregion
    }
}
