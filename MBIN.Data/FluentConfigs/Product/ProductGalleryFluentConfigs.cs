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
    public class ProductGalleryFluentConfigs : IEntityTypeConfiguration<ProductGallery>
    {
        public void Configure(EntityTypeBuilder<ProductGallery> builder)
        {
            builder.Property(b => b.ImageName).IsRequired().HasMaxLength(200);
            builder.HasOne(b => b.Product).WithMany(b => b.ProductGalleries).HasForeignKey(b => b.ProductId);
        }
    }
}
