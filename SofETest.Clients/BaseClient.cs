using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SofETest.Clients
{
    public class BaseClient
    {
        protected readonly HttpClient client;

        public BaseClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1432/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
