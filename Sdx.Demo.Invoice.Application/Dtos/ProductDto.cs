using Sdx.Demo.Invoice.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Sdx.Demo.Invoice.Application.Dtos
{
    public class ProductDto
    {
        [SwaggerSchema("Nombre del producto", ReadOnly = false, Title = "Producto", Nullable = false)]
        public string Name { get; set; }

    }
}
