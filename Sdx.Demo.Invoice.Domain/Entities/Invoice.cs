using System;
using System.Collections.Generic;

namespace Sdx.Demo.Invoice.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        /// <summary>
        /// Numero Factura
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Tipo de Pago
        /// </summary>
        public string PaymentType { get; private set; }

        /// <summary>
        /// Documento Cliente
        /// </summary>
        public string ClientDocument { get; private set; }

        /// <summary>
        /// Nombre Cliente
        /// </summary>
        public string ClientName { get; private set; }

        /// <summary>
        /// SubTotal
        /// </summary>
        public decimal SubTotal { get; private set; }

        /// <summary>
        /// Descuento
        /// </summary>
        public decimal Discount { get; private set; }

        /// <summary>
        /// IVA
        /// </summary>
        public decimal Iva { get; private set; }

        /// <summary>
        /// Total Descuento
        /// </summary>
        public decimal TotalDiscount { get; private set; }
        
        /// <summary>
        /// Total Impuesto
        /// </summary>
        public decimal TotalTax { get; private set; }

        /// <summary>
        /// Total
        /// </summary>
        public decimal Total { get; private set; }

        private readonly List<Product> _products;
        public IReadOnlyCollection<Product> Products => _products;

        public Invoice(int id) : base(id)
        {
            _products = new List<Product>();
        }

        public Invoice(int id, string number, DateTime date, string paymentType, string clientDocument, string clientName, decimal subTotal, decimal discount, decimal iva, decimal totalDiscount, decimal totalTax, decimal total, List<Product> products) : base(id)
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
            _products = products;
        }

        /// <summary>
        /// Adicionar producto a la factura
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
    }
}
