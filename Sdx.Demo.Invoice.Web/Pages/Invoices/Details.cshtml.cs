using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sdx.Demo.Invoice.Web.HttpClient;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class DetailsModel : PageModel
    {
        private readonly IInvoiceHttpClient _client;

        public DetailsModel(IInvoiceHttpClient client)
        {
            _client = client;
        }

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
    }
}
