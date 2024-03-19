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
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.CategoryName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Description).HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.ParentCategoryID).HasColumnType("int");

        }
    }
}
