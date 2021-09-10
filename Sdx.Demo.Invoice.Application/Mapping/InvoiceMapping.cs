using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sdx.Demo.Invoice.Application.Dtos;
using Sdx.Demo.Invoice.Application.ViewModels;

namespace Sdx.Demo.Invoice.Application.Mapping
{
    public class InvoiceMapping : Profile
    {
        public InvoiceMapping()
        {
            CreateMap<InvoiceDto, Invoice.Domain.Entities.Invoice>();

            CreateMap<Invoice.Domain.Entities.Invoice, InvoiceViewModel>();
        }
    }
}
