using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sdx.Demo.Invoice.Application.Dtos;
using Sdx.Demo.Invoice.Application.Exceptions;
using Sdx.Demo.Invoice.Application.Interfaces;
using Sdx.Demo.Invoice.Application.ViewModels;
using static Sdx.Demo.Invoice.Application.Domain.Invoices.Commands.AddInvoiceCommand;

namespace Sdx.Demo.Invoice.Application.Domain.Invoices.Commands
{
    public class UpdateInvoiceCommand : IRequest<InvoiceViewModel>
    {
        public int Id { get; set; }
        public InvoiceDto Invoice { get; set; }

        public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, InvoiceViewModel>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly IIntegrationEventService _integrationEventService;
            private readonly ILogger<UpdateInvoiceCommandHandler> _logger;

            public UpdateInvoiceCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IIntegrationEventService integrationEventService, ILogger<UpdateInvoiceCommandHandler> logger)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _integrationEventService = integrationEventService;
                _logger = logger;
            }

            public async Task<InvoiceViewModel> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
            {
                var invoice = await _dbContext.Invoices.FindAsync(request.Id);

                if (invoice == null) throw new NotFoundException(nameof(Invoice), request.Id);

                _mapper.Map(request.Invoice, invoice);
                await _integrationEventService.SaveContextChangesAsync();

                return _mapper.Map<InvoiceViewModel>(invoice);
            }
        }
    }
}
