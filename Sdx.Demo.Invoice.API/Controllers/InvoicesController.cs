using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Sdx.Demo.Invoice.Application.Domain.Invoices.Commands;
using Sdx.Demo.Invoice.Application.Domain.Invoices.Queries;
using Sdx.Demo.Invoice.Application.Dtos;
using Sdx.Demo.Invoice.Application.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace Sdx.Demo.Invoice.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna un listado de facturas",
            Description = "Retorna un listado de facturas", OperationId = "GET")]
        public async Task<ActionResult<IEnumerable<InvoiceViewModel>>> GetAll()
        {
            var invoices = await _mediator.Send(new GetAllInvoicesQuery());
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna una factura",
            Description = "Retorna una factura por un identificador", OperationId = "GET")]
        public async Task<ActionResult<InvoiceViewModel>> Get(int id)
        {
            var invoice = await _mediator.Send(new GetInvoiceQuery()
            {
                Id = id
            });
            return Ok(invoice);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crear una factura",
            Description = "Crear una factura", OperationId = "POST")]
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
