using System;
using System.Collections.Generic;
using Sdx.Demo.Invoice.Domain.Entities;

namespace Sdx.Demo.Invoice.Application.Dtos
{
    public class InvoiceDto
    {
        public string Number { get; set; }

        public DateTime Date { get; set; }

        public string PaymentType { get; set; }

        public string ClientDocument { get; set; }

        public string ClientName { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal Iva { get; set; }

        public decimal TotalDiscount { get; set; }

        public decimal TotalTax { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

    }
}
