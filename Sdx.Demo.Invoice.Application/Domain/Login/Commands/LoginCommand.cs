using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Internal;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Sdx.Demo.Invoice.Application.Dtos;

namespace Sdx.Demo.Invoice.Application.Domain.Login.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public LoginDto Login { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
        {
            private readonly IConfiguration _configuration;
            private readonly ILogger<LoginCommandHandler> _logger;

            public LoginCommandHandler(IConfiguration configuration, ILogger<LoginCommandHandler> logger)
            {
                _configuration = configuration;
                _logger = logger;
            }

            public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var login = request.Login;
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var token = new JwtSecurityToken(_configuration["JWT:ValidIssuer"], _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
}