﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sdx.Demo.Invoice.Domain.Entities;
using Sdx.Demo.Invoice.Infrastructure.Persistence.Context;
using Sdx.Demo.Invoice.Web.HttpClient;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.Pages.Invoices
{
    public class DetailsModel : PageModel
    {
        private readonly IInvoiceHttpClient _client;
        private readonly ApplicationDbContext _context;

        public DetailsModel(IInvoiceHttpClient client, ApplicationDbContext context)
        {
            _client = client;
            _context = context;
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
