using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sdx.Demo.Invoice.Application.Dtos;
using Sdx.Demo.Invoice.Application.Interfaces;
using Sdx.Demo.Invoice.Application.ViewModels;

namespace Sdx.Demo.Invoice.Application.Domain.Invoices.Commands
{
    public class AddInvoiceCommand : IRequest<InvoiceViewModel>
    {
        public InvoiceDto Invoice { get; set; }

        public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, InvoiceViewModel>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly IIntegrationEventService _integrationEventService;
            private readonly ILogger<AddInvoiceCommandHandler> _logger;

            public AddInvoiceCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IIntegrationEventService integrationEventService, ILogger<AddInvoiceCommandHandler> logger)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _integrationEventService = integrationEventService;
                _logger = logger;
            }

            public async Task<InvoiceViewModel> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
            {
                var invoice = _mapper.Map<Invoice.Domain.Entities.Invoice>(request.Invoice);
                await _dbContext.Invoices.AddAsync(invoice, cancellationToken);
                await _integrationEventService.SaveContextChangesAsync();

                return _mapper.Map<InvoiceViewModel>(invoice);
            }
        }

    }
}
