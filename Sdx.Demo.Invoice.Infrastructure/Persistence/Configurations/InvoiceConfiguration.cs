using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sdx.Demo.Invoice.Infrastructure.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Domain.Entities.Invoice>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Invoice> builder)
        {
            var tableName = "Facturas";
            builder.ToTable(tableName);
            builder.Property(d => d.Id).HasColumnName("IdFactura");
            builder.Property(d => d.Number).HasColumnName("NumeroFactura");
            builder.Property(d => d.Date).HasColumnName("Fecha");
            builder.Property(d => d.PaymentType).HasColumnName("TipoDePago");
            builder.Property(d => d.ClientDocument).HasColumnName("DocumentoCliente");
            builder.Property(d => d.ClientName).HasColumnName("NombreCliente");
            builder.Property(d => d.SubTotal).HasColumnName("SubTotal");
            builder.Property(d => d.Discount).HasColumnName("Descuento");
            builder.Property(d => d.Iva).HasColumnName("IVA");
            builder.Property(d => d.TotalDiscount).HasColumnName("TotalDescuento");
            builder.Property(d => d.TotalTax).HasColumnName("TotalImpuesto");
            builder.Property(d => d.Total).HasColumnName("Total");

        }
    }
}
