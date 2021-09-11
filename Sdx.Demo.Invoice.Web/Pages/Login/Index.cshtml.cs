using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sdx.Demo.Invoice.Web.HttpClient;

namespace Sdx.Demo.Invoice.Web.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly ILoginHttpClient _client;

        public IndexModel(ILoginHttpClient client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sdx.Demo.Invoice.Web.Models.UserModel UserModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Console.WriteLine($"{UserModel.UserName} - {UserModel.Password}");
            var token = await _client.GetToken(UserModel);
            Console.WriteLine(token);
            return Redirect("Invoices");
        }
    }
}
