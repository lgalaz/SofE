using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SofETest.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly SofETest.Services.ServicesFactory Services;

        public BaseApiController()
        {
            Services = new Services.ServicesFactory();
        }
    }
}