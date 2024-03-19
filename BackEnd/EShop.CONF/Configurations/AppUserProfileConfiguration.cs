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
    public class AppUserProfileConfiguration:BaseConfiguration<AppUserProfile>
    {
        public override void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            base.Configure(builder);
            builder.Property(x=>x.FirstName).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
