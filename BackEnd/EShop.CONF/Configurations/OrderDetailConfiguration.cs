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
    public class OrderDetailConfiguration:BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.OrderID,
                x.ProductID
            });
            builder.Property(x => x.UnitPrice).HasColumnType("money").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.OrderID).HasColumnType("int").IsRequired();
            builder.Property(x => x.ProductID).HasColumnType("int").IsRequired();
        }
    }
}
