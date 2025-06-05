using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBIN.Data.FluentConfigs.Product
{
    public class ProductFluentConfigs : IEntityTypeConfiguration<Entity.Product.Product>
    {
        public void Configure(EntityTypeBuilder<Entity.Product.Product> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.ShortDescription).IsRequired().HasMaxLength(800);
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.ImageName).IsRequired().HasMaxLength(500);
        }
    }
}
