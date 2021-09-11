using Sdx.Demo.Invoice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sdx.Demo.Invoice.Web.Models
{
    public class InvoiceModel
    {
        public string Id { get; set; }

        public string Number { get;  set; }

        public DateTime Date { get;  set; }

        public string PaymentType { get;  set; }

        public string ClientDocument { get;  set; }

        public string ClientName { get;  set; }

        public decimal SubTotal { get;  set; }

        public decimal Discount { get;  set; }

        public decimal Iva { get;  set; }

        public decimal TotalDiscount { get;  set; }

        public decimal TotalTax { get;  set; }

        public decimal Total { get;  set; }

        public IEnumerable<ProductModel> Products { get;  set; }
    }
}
