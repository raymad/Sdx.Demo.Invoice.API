﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Sdx.Demo.Invoice.Web.Data.SdxDemoInvoiceWebContext _context;

        public DeleteModel(Sdx.Demo.Invoice.Web.Data.SdxDemoInvoiceWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Entities.Invoice Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoice = await _context.Invoice.FirstOrDefaultAsync(m => m.Id == id);

            if (Invoice == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoice = await _context.Invoice.FindAsync(id);

            if (Invoice != null)
            {
                _context.Invoice.Remove(Invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
