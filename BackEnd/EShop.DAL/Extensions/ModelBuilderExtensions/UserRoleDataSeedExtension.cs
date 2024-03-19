using EShop.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Extensions.ModelBuilderExtensions
{
    public static class UserRoleDataSeedExtension
    {
        public static void SeedUserAdmin(ModelBuilder modelBuilder)
        {

            #region AdminUser
            IdentityRole<int> appRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString() //bu ifade sisteminizin yeni bir Guid yaratmasını saglar
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(appRole);

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            AppUser user = new()
            {
                Id = 1,
                UserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Admin123.")
            };

            modelBuilder.Entity<AppUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = appRole.Id,
                UserId = user.Id
            }); 
            #endregion


        }

        public static void SeedUserMember(ModelBuilder modelBuilder)
        {

            #region MemberUser
            IdentityRole<int> appRole = new()
            {
                Id = 2,
                Name = "Member",
                NormalizedName = "MEMBER",
                ConcurrencyStamp = Guid.NewGuid().ToString() //bu ifade sisteminizin yeni bir Guid yaratmasını saglar
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(appRole);

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            AppUser user = new()
            {
                Id = 2,
                UserName = "member123",
                Email = "member@gmail.com",
                NormalizedEmail = "MEMBER@GMAIL.COM",
                NormalizedUserName = "MEMBER",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Member123.")
            };

            modelBuilder.Entity<AppUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = appRole.Id,
                UserId = user.Id
            });
            #endregion


        }

        public static void SeedSellerMember(ModelBuilder modelBuilder)
        {

            #region SellerUser
            IdentityRole<int> appRole = new()
            {
                Id = 3,
                Name = "Seller",
                NormalizedName = "SELLER",
                ConcurrencyStamp = Guid.NewGuid().ToString() //bu ifade sisteminizin yeni bir Guid yaratmasını saglar
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(appRole);

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            AppUser user = new()
            {
                Id = 3,
                UserName = "seller123",
                Email = "seller@gmail.com",
                NormalizedEmail = "SELLER@GMAIL.COM",
                NormalizedUserName = "SELLER",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Seller123.")
            };

            modelBuilder.Entity<AppUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = appRole.Id,
                UserId = user.Id
            });
            #endregion


        }
    }
}
