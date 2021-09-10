using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Sdx.Demo.Invoice.Domain.Entities;

namespace Sdx.Demo.Invoice.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Invoice.Domain.Entities.Invoice> Invoices { get; set; }

        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
