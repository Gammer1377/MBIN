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
    public class ProductSelectedCategoriesFluentConfigs : IEntityTypeConfiguration<ProductSelectedCategories>
    {
        public void Configure(EntityTypeBuilder<ProductSelectedCategories> builder)
        {
            builder.HasKey(b => new { b.ProductId, b.ProductCategoryId });
            builder.HasOne(b => b.Product).WithMany(b => b.ProductSelectedCategories).HasForeignKey(b => b.ProductId);
            builder.HasOne(b => b.ProductCategory).WithMany(b => b.ProductSelectedCategories).HasForeignKey(b => b.ProductCategoryId);
        }
    }
}
