using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Sdx.Demo.Invoice.Application.Domain.Invoice.Commands
{
    public class RemoveInvoiceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
