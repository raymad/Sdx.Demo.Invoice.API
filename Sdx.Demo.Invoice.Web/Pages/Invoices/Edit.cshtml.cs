using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sdx.Demo.Invoice.Web.HttpClient;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly IInvoiceHttpClient _client;

        public EditModel(IInvoiceHttpClient client)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Invoice = await _client.UpdateInvoice(Invoice);

            return RedirectToPage("./Index");
        }

    }
}
