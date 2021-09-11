using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sdx.Demo.Invoice.Domain.Entities;
using Sdx.Demo.Invoice.Web.Data;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly Sdx.Demo.Invoice.Web.Data.SdxDemoInvoiceWebContext _context;

        public IndexModel(Sdx.Demo.Invoice.Web.Data.SdxDemoInvoiceWebContext context)
        {
            _context = context;
        }

        public IList<Domain.Entities.Invoice> Invoice { get;set; }

        public async Task OnGetAsync()
        {
            Invoice = await _context.Invoice.ToListAsync();
        }
    }
}
