using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Sdx.Demo.Invoice.Application.Dtos;
using Sdx.Demo.Invoice.Application.ViewModels;

namespace Sdx.Demo.Invoice.Application.Domain.Invoice.Commands
{
    public class UpdateInvoiceCommand : IRequest<InvoiceViewModel>
    {
        public int Id { get; set; }
        public InvoiceDto Invoice { get; set; }
    }
}
