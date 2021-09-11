using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sdx.Demo.Invoice.Web.Models;

namespace Sdx.Demo.Invoice.Web.HttpClient
{
    public interface IInvoiceHttpClient
    {
        Task<IList<InvoiceModel>> GetInvoices();
        Task<InvoiceModel> GetInvoice(int? id);
        Task<InvoiceModel> CreateInvoice(InvoiceModel invoice);
        Task<InvoiceModel> UpdateInvoice(InvoiceModel invoice);
        Task RemoveInvoice(int? id);

    }

    public class InvoiceHttpClient : IInvoiceHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;
        private const string BaseUrl = "api/Invoices";

        public InvoiceHttpClient(System.Net.Http.HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<InvoiceModel>> GetInvoices()
        {

            var response = await _client.GetAsync(BaseUrl);

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return CreateObject<IList<InvoiceModel>>(content);
            }

            throw new Exception($"Error Get Invoices. {response.ReasonPhrase} | {content}");
        }

        public async Task<InvoiceModel> GetInvoice(int? id)
        {
            var response = await _client.GetAsync($"{BaseUrl}/{id}");

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return CreateObject<InvoiceModel>(content);
            }

            throw new Exception($"Error Get Invoice. {response.ReasonPhrase} | {content}");
        }

        public async Task<InvoiceModel> CreateInvoice(InvoiceModel invoice)
        {
            var stringContent = GetObject(invoice);

            var response = await _client.PostAsync(BaseUrl, stringContent);

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return CreateObject<InvoiceModel>(content);
            }

            throw new Exception($"Error Creating Invoice. {response.ReasonPhrase} | {content}");
        }

        public async Task<InvoiceModel> UpdateInvoice(InvoiceModel invoice)
        {
            var stringContent = GetObject(invoice);

            var response = await _client.PostAsync($"{BaseUrl}/{invoice.Id}", stringContent);

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return CreateObject<InvoiceModel>(content);
            }

            throw new Exception($"Error Updating Invoice. {response.ReasonPhrase} | {content}");
        }

        public async Task RemoveInvoice(int? id)
        {
            var response = await _client.DeleteAsync($"{BaseUrl}/{id}");

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error Updating Invoice. {response.ReasonPhrase} | {content}");
            }
            
        }

        private StringContent GetObject(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        private T CreateObject<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

    }
}
