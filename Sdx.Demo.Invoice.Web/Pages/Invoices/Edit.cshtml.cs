﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sdx.Demo.Invoice.Domain.Entities;
using Sdx.Demo.Invoice.Web.Data;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly Sdx.Demo.Invoice.Web.Data.SdxDemoInvoiceWebContext _context;

        public EditModel(Sdx.Demo.Invoice.Web.Data.SdxDemoInvoiceWebContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(Invoice.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
