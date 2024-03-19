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
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x=>x.ProductName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("money").IsRequired();
            builder.Property(x => x.UnitsInStock).HasColumnType("int").IsRequired();
            builder.Property(x=>x.KDV).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.OTV).HasColumnType("decimal");
        }
    }
}
