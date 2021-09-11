using System;
using System.Collections.Generic;
using Sdx.Demo.Invoice.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Sdx.Demo.Invoice.Application.Dtos
{
    public class InvoiceDto
    {
        [SwaggerSchema("Numero de Factura", ReadOnly = false, Title = "NumeroFactura", Nullable = false)]
        public string Number { get; set; }

        [SwaggerSchema("Fecha", ReadOnly = false, Title = "Fecha", Nullable = false)]
        public DateTime Date { get; set; }

        [SwaggerSchema("Tipo de Pago", ReadOnly = false, Title = "TipoDePago", Nullable = false)]
        public string PaymentType { get; set; }

        [SwaggerSchema("Documento del cliente", ReadOnly = false, Title = "DocumentoCliente", Nullable = false)]
        public string ClientDocument { get; set; }

        [SwaggerSchema("Nombre del cliente", ReadOnly = false, Title = "NombreCliente", Nullable = false)]
        public string ClientName { get; set; }

        [SwaggerSchema("SubTotal", ReadOnly = false, Title = "SubTotal", Nullable = false)]
        public decimal SubTotal { get; set; }

        [SwaggerSchema("Descuento", ReadOnly = false, Title = "Descuento", Nullable = false)]
        public decimal Discount { get; set; }

        [SwaggerSchema("IVA", ReadOnly = false, Title = "IVA", Nullable = false)]
        public decimal Iva { get; set; }

        [SwaggerSchema("Descuento total", ReadOnly = false, Title = "DescuentoTotal", Nullable = false)]
        public decimal TotalDiscount { get; set; }

        [SwaggerSchema("Total de Impuestos", ReadOnly = false, Title = "TotalImpuesto", Nullable = false)]
        public decimal TotalTax { get; set; }

        [SwaggerSchema("Total", ReadOnly = false, Title = "Total", Nullable = false)]
        public decimal Total { get; set; }

        [SwaggerSchema("Listado de productos", ReadOnly = false, Title = "Productos", Nullable = false)]
        public IEnumerable<ProductDto> Products { get; set; }

    }
}
