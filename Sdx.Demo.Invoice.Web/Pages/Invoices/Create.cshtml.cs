using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sdx.Demo.Invoice.Domain.Entities;
using Sdx.Demo.Invoice.Web.Data;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly Sdx.Demo.Invoice.Web.Data.SdxDemoInvoiceWebContext _context;

        public CreateModel(Sdx.Demo.Invoice.Web.Data.SdxDemoInvoiceWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Invoice Invoice { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Invoice.Add(Invoice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
