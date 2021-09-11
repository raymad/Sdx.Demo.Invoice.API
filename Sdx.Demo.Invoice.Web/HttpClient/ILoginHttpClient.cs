using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.HttpClient
{
    public interface ILoginHttpClient
    {
        Task<string> GetToken(UserModel userModel);
    }

    public class LoginHttpClient : ILoginHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;
        private const string BaseUrl = "api/Authenticate/login";

        public LoginHttpClient(System.Net.Http.HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetToken(UserModel userModel)
        {
            var stringContent = GetObject(userModel);

            var response = await _client.PostAsync(BaseUrl, stringContent);

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception($"Error Login. {response.ReasonPhrase} | {content}");
        }

        private StringContent GetObject(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
