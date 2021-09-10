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
        public string Name { get; private set; }


        /// <summary>
        /// Relacion con Factura
        /// </summary>
        public int InvoiceId { get; private set; }
        public Invoice Invoice { get; private set; }

        public Product(int id, string name) : base(id)
        {
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

    }
}
