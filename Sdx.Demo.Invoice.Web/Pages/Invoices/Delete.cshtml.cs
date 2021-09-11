using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sdx.Demo.Invoice.Web.HttpClient;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly IInvoiceHttpClient _client;

        public DeleteModel(IInvoiceHttpClient client)
        {
            _client = client;
        }

        [BindProperty]
        public InvoiceModel Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoice = await _client.GetInvoice(id);

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

            Invoice = await _client.GetInvoice(id);

            if (Invoice != null)
            {
                await _client.RemoveInvoice(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
