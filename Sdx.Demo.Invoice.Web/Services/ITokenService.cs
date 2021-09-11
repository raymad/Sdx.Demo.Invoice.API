using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sdx.Demo.Invoice.Web.Services
{
    public interface ITokenService
    {
        string Token { get; set; }
    }

    public class TokenService : ITokenService
    {
        public string Token { get; set; }
    }
}
