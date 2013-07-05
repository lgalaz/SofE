using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using SofETest.WebAdmin.Models;

namespace SofETest.Clients
{
    public class ContributorClient : BaseClient
    {
        public IEnumerable<Contributor> GetAll()
        {
            IEnumerable<Contributor> contributors = null;
            HttpResponseMessage response = client.GetAsync("api/contributors").Result; 
            if (response.IsSuccessStatusCode)
            {
                contributors = response.Content.ReadAsAsync<IEnumerable<Contributor>>().Result;
            }
            return contributors;
        }

        public Contributor Get(int id)
        {
            Contributor contributor = null;

            HttpResponseMessage response = client.GetAsync(string.Format("api/contributors/{0}", id)).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var product = response.Content.ReadAsAsync<Contributor>().Result;
            }

            return contributor;
        }

        public void Create(Contributor contributor)
        {
            Uri contributorUri = null;

            HttpResponseMessage response = client.PostAsJsonAsync("api/contributors", contributor).Result;
            if (response.IsSuccessStatusCode)
            {
                contributorUri = response.Headers.Location;
            }
        }

        public string Update(Contributor contributor)
        {
            HttpResponseMessage response = client.PutAsJsonAsync("api/contributors", contributor).Result;
            string responseMsg = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            return responseMsg;
        }

        public string Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(string.Format("api/contributors/{0}",id)).Result;
            string responseMsg = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            return responseMsg;
        }
    }
}
