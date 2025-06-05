using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Common;

namespace MBIN.Entity.Product
{
    public class ProductFeature:BaseEntity
    {
        public int ProductId { get; set; }
        public string FeatureTitle { get; set; }
        public String FeatureValue { get; set; }

        #region Relations

        public Product Product { get; set; }

        #endregion
    }
}
