using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBIN.Data.FluentConfigs.Blog
{
    public class BlogFluentConfigs : IEntityTypeConfiguration<Entity.Blog.Blog>
    {
        public void Configure(EntityTypeBuilder<Entity.Blog.Blog> builder)
        {
          
        }
    }
}
