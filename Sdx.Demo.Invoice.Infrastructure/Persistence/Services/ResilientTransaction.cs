using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sdx.Demo.Invoice.Infrastructure.Persistence.Services
{
    public class ResilientTransaction
    {
        private readonly DbContext _context;
        private ResilientTransaction(DbContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public static ResilientTransaction New(DbContext context) =>
            new ResilientTransaction(context);

        public async Task ExecuteAsync(Func<Task> action)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    await action();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }
    }
}
