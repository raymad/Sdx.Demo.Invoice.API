using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sdx.Demo.Invoice.Domain.Entities;
using Sdx.Demo.Invoice.Infrastructure.Persistence.Context;
using Sdx.Demo.Invoice.Web.HttpClient;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly IInvoiceHttpClient _client;
        private readonly ApplicationDbContext _context;

        public CreateModel(IInvoiceHttpClient client, ApplicationDbContext context)
        {
            _client = client;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InvoiceModel Invoice { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Console.WriteLine($"{Invoice.ClientDocument}");
            await _client.CreateInvoice(Invoice);

            return RedirectToPage("./Index");
        }
    }
}
