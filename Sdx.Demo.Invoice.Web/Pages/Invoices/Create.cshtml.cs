using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sdx.Demo.Invoice.Web.HttpClient;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly IInvoiceHttpClient _client;

        public CreateModel(IInvoiceHttpClient client)
        {
            _client = client;
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
