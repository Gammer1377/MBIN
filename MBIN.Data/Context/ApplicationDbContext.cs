using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using MBIN.Data.FluentConfigs;
using MBIN.Data.FluentConfigs.Product;
using MBIN.Data.FluentConfigs.User;
using MBIN.Entity.Product;
using MBIN.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MBIN.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserFluentConfigs());
            modelBuilder.ApplyConfiguration(new ProductFluentConfigs());
            modelBuilder.ApplyConfiguration(new ProductCategoryFluentConfigs());
            modelBuilder.ApplyConfiguration(new ProductFeatureFluentConfigs());
            modelBuilder.ApplyConfiguration(new ProductSelectedCategoriesFluentConfigs());
        }

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSelectedCategories> ProductSelectedCategories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }

        #endregion
    }
}
