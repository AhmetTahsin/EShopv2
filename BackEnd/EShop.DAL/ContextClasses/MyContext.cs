using EShop.CONF.Configurations;
using EShop.DAL.Extensions.ModelBuilderExtensions;
using EShop.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.ContextClasses
{
    public class MyContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new AppUserProfileConfiguration());

            CategoryDataSeedExtension.SeedCategories(builder); // Fake Veri
            UserRoleDataSeedExtension.SeedUserAdmin(builder);
            UserRoleDataSeedExtension.SeedUserMember(builder);
            UserRoleDataSeedExtension.SeedSellerMember(builder);
            ProductDataSeedExtension.SeedProduct(builder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }

    }
}
