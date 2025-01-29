using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vila.WebApi.Utility;

namespace MBIN.Data.FluentConfigs.User
{
    public class UserFluentConfigs : IEntityTypeConfiguration<Entity.User.User>
    {
        public void Configure(EntityTypeBuilder<Entity.User.User> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(b => b.UserName).HasMaxLength(30).IsRequired();
            builder.Property(b => b.Password).IsRequired().HasMaxLength(30);
            builder.Property(b => b.Gender).IsRequired();
            builder.Property(b => b.Email).IsRequired().HasMaxLength(30);
            builder.Ignore(b => b.JWTSecret);
            builder.HasData(new Entity.User.User
            {
                Id = 1,
                UserName = "MobinEfati",
                Email = "MobinEffati@gmail.com",
                Password = PasswordHelper.EncodeProSecurity("12481632"),
                CreateDate = new DateTime(2025, 1, 22),
                LastUpdateDate = new DateTime(2025, 1, 22),
                Gender = true
            },
            new Entity.User.User
            {
                Id = 2,
                UserName = "ElhamAzizzade",
                Email = "ElhamAzizzade@gmail.com",
                Password = PasswordHelper.EncodeProSecurity("12481632"),
                CreateDate = new DateTime(2025, 1, 22),
                LastUpdateDate = new DateTime(2025, 1, 22),
                Gender = false
            });

        }
    }
}
