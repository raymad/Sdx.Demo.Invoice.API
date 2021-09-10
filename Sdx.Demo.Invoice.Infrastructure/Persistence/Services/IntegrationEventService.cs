using Sdx.Demo.Invoice.Application.Interfaces;
using Sdx.Demo.Invoice.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sdx.Demo.Invoice.Infrastructure.Persistence.Services
{
    public class IntegrationEventService : IIntegrationEventService
    {
        private readonly ApplicationDbContext _context;

        public IntegrationEventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveContextChangesAsync()
        {
            await ResilientTransaction.New(_context).ExecuteAsync(async () => await _context.SaveChangesAsync());
        }
    }
}
