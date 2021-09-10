using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sdx.Demo.Invoice.Application.Domain.Invoice.Commands;
using Sdx.Demo.Invoice.Application.Domain.Invoice.Queries;
using Sdx.Demo.Invoice.Application.Dtos;
using Sdx.Demo.Invoice.Application.ViewModels;

namespace Sdx.Demo.Invoice.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceViewModel>>> GetAll()
        {
            var invoices = await _mediator.Send(new GetAllInvoicesQuery());
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceViewModel>> Get(int id)
        {
            var invoice = await _mediator.Send(new GetInvoiceQuery()
            {
                Id = id
            });
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceViewModel>> Create(InvoiceDto invoiceDto)
        {
            var invoice = await _mediator.Send(new AddInvoiceCommand()
            {
                Invoice = invoiceDto
            });
            return Ok(invoice);
        }


    }
}
