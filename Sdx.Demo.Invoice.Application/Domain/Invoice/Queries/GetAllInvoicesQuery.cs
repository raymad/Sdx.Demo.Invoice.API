using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sdx.Demo.Invoice.Application.Exceptions;
using Sdx.Demo.Invoice.Application.Interfaces;
using Sdx.Demo.Invoice.Application.ViewModels;
using static Sdx.Demo.Invoice.Application.Domain.Invoice.Queries.GetInvoiceQuery;

namespace Sdx.Demo.Invoice.Application.Domain.Invoice.Queries
{
    public class GetAllInvoicesQuery : IRequest<IEnumerable<InvoiceViewModel>>
    {
        public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, IEnumerable<InvoiceViewModel>>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;
            private readonly ILogger<GetAllInvoicesQueryHandler> _logger;

            public GetAllInvoicesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper, ILogger<GetAllInvoicesQueryHandler> logger)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<IEnumerable<InvoiceViewModel>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
            {
                var invoices = await _applicationDbContext
                    .Invoices
                    .Include(i => i.Products)
                    .ToListAsync(cancellationToken);

                return invoices.Select(i => _mapper.Map<InvoiceViewModel>(i));
            }
        }
    }
}
