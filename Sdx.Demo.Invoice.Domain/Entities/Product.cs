using System;
using System.Collections.Generic;
using System.Text;

namespace Sdx.Demo.Invoice.Domain.Entities
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Producto
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Relacion con Factura
        /// </summary>
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public Product()
        {
        }

        public Product(int id, string name) : base(id)
        {
            Name = name;
        }

    }
}
