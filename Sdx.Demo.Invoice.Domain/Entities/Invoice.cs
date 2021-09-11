using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdx.Demo.Invoice.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        /// <summary>
        /// Numero Factura
        /// </summary>
        public string Number { get;  set; }

        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Date { get;  set; }

        /// <summary>
        /// Tipo de Pago
        /// </summary>
        public string PaymentType { get;  set; }

        /// <summary>
        /// Documento Cliente
        /// </summary>
        public string ClientDocument { get;  set; }

        /// <summary>
        /// Nombre Cliente
        /// </summary>
        public string ClientName { get;  set; }

        /// <summary>
        /// SubTotal
        /// </summary>
        public decimal SubTotal { get;  set; }

        /// <summary>
        /// Descuento
        /// </summary>
        public decimal Discount { get;  set; }

        /// <summary>
        /// IVA
        /// </summary>
        public decimal Iva { get;  set; }

        /// <summary>
        /// Total Descuento
        /// </summary>
        public decimal TotalDiscount { get;  set; }
        
        /// <summary>
        /// Total Impuesto
        /// </summary>
        public decimal TotalTax { get;  set; }

        /// <summary>
        /// Total
        /// </summary>
        public decimal Total { get;  set; }

        public IEnumerable<Product> Products { get; set; }

        public Invoice(int id) : base(id)
        {
            Products = new List<Product>();
        }

        public Invoice(string number, DateTime date, string paymentType, string clientDocument, string clientName, decimal subTotal, decimal discount, decimal iva, decimal totalDiscount, decimal totalTax, decimal total, IEnumerable<Product> products)
        {
            Number = number;
            Date = date;
            PaymentType = paymentType;
            ClientDocument = clientDocument;
            ClientName = clientName;
            SubTotal = subTotal;
            Discount = discount;
            Iva = iva;
            TotalDiscount = totalDiscount;
            TotalTax = totalTax;
            Total = total;
            Products = products;
        }

        /// <summary>
        /// Adicionar producto a la factura
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            Products.ToList().Add(product);
        }
    }
}
