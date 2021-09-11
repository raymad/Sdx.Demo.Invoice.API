using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sdx.Demo.Invoice.Web.Models;
using Sdx.Demo.Invoice.Web.Services;

namespace Sdx.Demo.Invoice.Web.HttpClient
{
    public interface ILoginHttpClient
    {
        Task<string> GetToken(UserModel userModel);
    }

    public class LoginHttpClient : ILoginHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;
        private readonly ITokenService _tokenService;
        private const string BaseUrl = "api/Authenticate/login";

        public LoginHttpClient(System.Net.Http.HttpClient client, ITokenService tokenService)
        {
            _client = client;
            _tokenService = tokenService;
        }

        public async Task<string> GetToken(UserModel userModel)
        {
            var stringContent = GetObject(userModel);

            var response = await _client.PostAsync(BaseUrl, stringContent);

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                _tokenService.Token = content;
                return content;
            }

            throw new Exception($"Error Login. {response.ReasonPhrase} | {content}");
        }

        private StringContent GetObject(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
