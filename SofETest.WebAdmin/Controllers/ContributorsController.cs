using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SofETest.Clients;
using SofETest.WebAdmin.Models;

namespace SofETest.WebAdmin.Controllers
{
    public class ContributorsController : BaseApiController
    {
        // GET api/contributors
        [HttpGet]
        public IEnumerable<Contributor> Get()
        {
            return client.Contributors.GetAll();
        }

        // GET api/contributors/5
        [HttpGet]
        public Contributor Get(int id)
        {
            return client.Contributors.Get(id);
        }

        // POST api/contributors
        [HttpPost]
        public void Post([FromBody]Contributor contributor)
        {
            client.Contributors.Create(contributor);
        }

        // PUT api/contributors, id comes with the object.
        [HttpPut]
        public string Put([FromBody]Contributor contributor)
        {
            return client.Contributors.Update(contributor);
        }

        // DELETE api/contributors/5
        [HttpDelete]
        public string Delete(int id)
        {
            return client.Contributors.Delete(id);
        }
    }
}
