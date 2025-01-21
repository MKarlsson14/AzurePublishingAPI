
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Common;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlazorAzurePublishing.Data
{
    public class APIService : IAPIService
    {
        private readonly IHttpClientFactory factory;

        public APIService(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        public async Task<List<T>?> GetAllFromApiAsync<T>() where T : class
        {
            var response = await factory.CreateClient("CustomClient")
                                        .GetAsync("api/" + typeof(T).Name);

            List<T>? data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<List<T>>() : null;
            return data;
        }
    }
}
