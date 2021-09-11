﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sdx.Demo.Invoice.Infrastructure.Persistence.Context;

namespace Sdx.Demo.Invoice.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sdx.Demo.Invoice.Domain.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdFactura")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientDocument")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DocumentoCliente");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NombreCliente");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Descuento");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("IVA");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NumeroFactura");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoDePago");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("SubTotal");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Total");

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TotalDescuento");

                    b.Property<decimal>("TotalTax")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TotalImpuesto");

                    b.HasKey("Id");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Sdx.Demo.Invoice.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdProducto")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Producto");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Sdx.Demo.Invoice.Domain.Entities.Product", b =>
                {
                    b.HasOne("Sdx.Demo.Invoice.Domain.Entities.Invoice", "Invoice")
                        .WithMany("Products")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Sdx.Demo.Invoice.Domain.Entities.Invoice", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}