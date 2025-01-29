using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using MBIN.Data.FluentConfigs;
using MBIN.Data.FluentConfigs.Blog;
using MBIN.Data.FluentConfigs.User;
using MBIN.Entity.Blog;
using MBIN.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MBIN.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserFluentConfigs());
            modelBuilder.ApplyConfiguration(new BlogCategoryFluentConfigs());
            modelBuilder.ApplyConfiguration(new BlogFluentConfigs());
        }

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        #endregion
    }
}
