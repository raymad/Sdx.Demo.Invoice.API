using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sdx.Demo.Invoice.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
        {
            var tableName = "Productos";
            builder.ToTable(tableName);
            builder.Property(d => d.Id).HasColumnName("IdProducto");
            builder.Property(d => d.Name).HasColumnName("Producto");
        }
    }
}
