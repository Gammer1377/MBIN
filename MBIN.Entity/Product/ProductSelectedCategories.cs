using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Common;

namespace MBIN.Entity.Product
{
    public class ProductSelectedCategories : BaseEntity
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }

        #region Relations

        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }

        #endregion
    }
}
