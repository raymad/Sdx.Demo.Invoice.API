using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sdx.Demo.Invoice.Application.Dtos;
using Sdx.Demo.Invoice.Application.ViewModels;
using Sdx.Demo.Invoice.Domain.Entities;

namespace Sdx.Demo.Invoice.Application.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductViewModel>();
        }
    }
}
