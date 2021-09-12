using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Sdx.Demo.Invoice.Application.Exceptions;
using Sdx.Demo.Invoice.Application.Interfaces;

namespace Sdx.Demo.Invoice.Application.Domain.Invoices.Commands
{
    public class RemoveInvoiceCommand : IRequest
    {
        public int Id { get; set; }

        public class RemoveInvoiceCommandHandler : IRequestHandler<RemoveInvoiceCommand, Unit>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IIntegrationEventService _integrationEventService;
            private readonly ILogger<RemoveInvoiceCommandHandler> _logger;

            public RemoveInvoiceCommandHandler(IApplicationDbContext dbContext, IIntegrationEventService integrationEventService, ILogger<RemoveInvoiceCommandHandler> logger)
            {
                _dbContext = dbContext;
                _integrationEventService = integrationEventService;
                _logger = logger;
            }

            public async Task<Unit> Handle(RemoveInvoiceCommand request, CancellationToken cancellationToken)
            {
                var invoice = await _dbContext.Invoices.FindAsync(request.Id);

                if (invoice == null) throw new NotFoundException(nameof(Invoice), request.Id);

                _dbContext.Invoices.Remove(invoice);
                await _integrationEventService.SaveContextChangesAsync();

                return Unit.Value;
            }
        }
    }
}
