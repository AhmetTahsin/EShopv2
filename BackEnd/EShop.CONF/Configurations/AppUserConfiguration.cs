using EShop.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.CONF.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID); // Identity'in Kendi id'si var 
            builder.Property(x => x.UserName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasColumnType("nvarchar").HasMaxLength(128).IsRequired();


            builder.HasMany(x => x.Orders).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserID);  //1-M ilişkiyi normalde yazmama gerek yok ama Identity oldugu yazıldı
            builder.HasOne(x => x.Profile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.ID); //1-1
        }
    }
}
