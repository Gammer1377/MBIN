using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Common;

namespace MBIN.Entity.Product
{
    public class ProductGallery:BaseEntity
    {
        public long ProductId { get; set; }     
        public string ImageName { get; set; }

        #region Relations

        public Product Product { get; set; }

        #endregion
    }
}
