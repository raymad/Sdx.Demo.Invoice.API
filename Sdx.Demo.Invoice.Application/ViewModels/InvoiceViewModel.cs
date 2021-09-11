using System;
using System.Collections.Generic;
using System.Text;
using Sdx.Demo.Invoice.Application.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace Sdx.Demo.Invoice.Application.ViewModels
{
    public class InvoiceViewModel : InvoiceDto
    {
        public int Id { get; set; }

        [SwaggerSchema("Listado de productos", ReadOnly = false, Title = "Productos", Nullable = false)]
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
