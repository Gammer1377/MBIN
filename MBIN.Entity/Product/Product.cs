using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Common;

namespace MBIN.Entity.Product
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }

        #region Relations

        public ICollection<ProductGallery> ProductGalleries { get; set; }
        public ICollection<ProductSelectedCategories> ProductSelectedCategories { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }

        #endregion

    }
}
