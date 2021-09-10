using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Sdx.Demo.Invoice.Application.ViewModels;

namespace Sdx.Demo.Invoice.Application.Domain.Invoice.Queries
{
    public class GetAllInvoicesQuery : IRequest<IEnumerable<InvoiceViewModel>>
    {
    }
}
