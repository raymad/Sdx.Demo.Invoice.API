using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sdx.Demo.Invoice.Domain.Entities;

namespace Sdx.Demo.Invoice.Web.Data
{
    public class SdxDemoInvoiceWebContext : DbContext
    {
        public SdxDemoInvoiceWebContext (DbContextOptions<SdxDemoInvoiceWebContext> options)
            : base(options)
        {
        }

        public DbSet<Sdx.Demo.Invoice.Domain.Entities.Invoice> Invoice { get; set; }
    }
}
