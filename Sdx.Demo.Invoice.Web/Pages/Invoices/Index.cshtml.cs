using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sdx.Demo.Invoice.Web.HttpClient;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly IInvoiceHttpClient _client;

        public IndexModel(IInvoiceHttpClient client)
        {
            _client = client;
        }

        public IList<InvoiceModel> Invoice { get;set; }

        public async Task OnGetAsync()
        {
            Invoice = await _client.GetInvoices();
        }
    }
}
