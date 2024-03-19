using EShop.ENTITIES.CoreInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.CONF.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder) //Ayarlamaları Miras yolu ile yapacağız virtual o yüzden yazdım
        {
            builder.Property(x=>x.ID).HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ModifiedDate).HasColumnType("datetime");
            builder.Property(x => x.DeletedDate).HasColumnType("datetime");
            builder.Property(x=>x.Status).HasColumnType("int").IsRequired();

        }
    }
}
