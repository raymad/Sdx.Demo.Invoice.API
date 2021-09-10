using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sdx.Demo.Invoice.Application.Interfaces;
using Sdx.Demo.Invoice.Domain.Entities;

namespace Sdx.Demo.Invoice.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Domain.Entities.Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
