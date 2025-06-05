using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBIN.Data.FluentConfigs.Product
{
    public class ProductCategoryFluentConfigs : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(b => b.Title).IsRequired().HasMaxLength(500);
            builder.Property(b => b.UrlName).IsRequired().HasMaxLength(200);
            builder.Property(b => b.ImageName).IsRequired().HasMaxLength(500);

            #region Relations

            

            #endregion
        }
    }
}
