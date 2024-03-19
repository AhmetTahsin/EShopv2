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
    public class OrderConfiguration:BaseConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.Property(x=>x.ShippingAddress).HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            builder.Property(x => x.Email).HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            builder.Property(x=>x.NameDescription).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x=>x.PriceOfOrder).HasColumnType("money").IsRequired();
            builder.Property(x => x.AppUserID).HasColumnType("int");
        }
    }
}
