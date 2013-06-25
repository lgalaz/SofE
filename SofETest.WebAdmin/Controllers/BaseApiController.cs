using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SofETest.WebAdmin.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly SofETest.Clients.ClientFactory client;

        public BaseApiController()
        {
            client = new Clients.ClientFactory();
        }
    }
}
