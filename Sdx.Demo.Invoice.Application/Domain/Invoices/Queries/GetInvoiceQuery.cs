using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sdx.Demo.Invoice.Application.Exceptions;
using Sdx.Demo.Invoice.Application.Interfaces;
using Sdx.Demo.Invoice.Application.ViewModels;

namespace Sdx.Demo.Invoice.Application.Domain.Invoices.Queries
{
    public class GetInvoiceQuery : IRequest<InvoiceViewModel>
    {
        public int Id { get; set; }

        public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, InvoiceViewModel>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;
            private readonly ILogger<GetInvoiceQueryHandler> _logger;

            public GetInvoiceQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper, ILogger<GetInvoiceQueryHandler> logger)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<InvoiceViewModel> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
            {
                var invoice = await _applicationDbContext
                    .Invoices
                    .Include(i => i.Products)
                    .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

                if (invoice == null)
                    throw new NotFoundException(nameof(Demo.Invoice.Domain.Entities.Invoice), request.Id);

                return _mapper.Map<InvoiceViewModel>(invoice);
            }
        }
    }
}
