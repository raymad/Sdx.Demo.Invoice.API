using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sdx.Demo.Invoice.Application.Domain.Login.Commands;
using Sdx.Demo.Invoice.Application.Dtos;
using Serilog;

namespace Sdx.Demo.Invoice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var token = await _mediator.Send(new LoginCommand
            {
                Login = login
            });

            if (string.IsNullOrEmpty(token)) return Unauthorized();

            return Ok(token);
        }

    }
}
