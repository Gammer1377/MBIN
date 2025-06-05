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
    public class ProductFeatureFluentConfigs : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.Property(b => b.FeatureTitle).IsRequired().HasMaxLength(200);
            builder.Property(b => b.FeatureValue).IsRequired().HasMaxLength(200);
            builder.HasOne(b => b.Product).WithMany(b => b.ProductFeatures).HasForeignKey(b => b.ProductId);
        }
    }
}
