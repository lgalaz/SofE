using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SofETest.WebAPI.Filters;
using SofETest.WebAPI.Models;

namespace SofETest.WebAPI.Controllers
{   
    public class ContributorsController : BaseApiController
    {
        // GET api/contributors
        [Queryable]
        public IQueryable<SofETest.Models.Contributor> Get()
        {
            IEnumerable<SofETest.Models.Contributor> contributors = Services.Contributors.GetAll();
            return contributors.AsQueryable<SofETest.Models.Contributor>();
        }

        // GET api/contributors/5
        public SofETest.Models.Contributor Get(int id)
        {
            SofETest.Models.Contributor contributor = null;

            contributor = Services.Contributors.Get(id);

            return contributor;     
        }

        // POST api/contributors
        [ValidationActionFilter]
        public HttpResponseMessage Post(Contributor contributor)
        {
            HttpResponseMessage response = null;
            try
            {
                Mapper.CreateMap<Contributor, SofETest.Models.Contributor>();
                SofETest.Models.Contributor c = Mapper.Map<Contributor, SofETest.Models.Contributor>(contributor);

                Services.Contributors.Create(c);
                response = Request.CreateResponse(HttpStatusCode.Created, contributor);
                string uri = Url.Route(null, new { id = c.Id });
                response.Headers.Location = new Uri(Request.RequestUri, uri);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("\r\n", "\r\n ");
                response = new HttpResponseMessage(HttpStatusCode.Conflict);
                response.Headers.Add("Error-Description", msg);
            }
            return response;       
        }

        // PUT api/contributors/5
        [ValidationActionFilter]
        public HttpResponseMessage Put([FromBody]ContributorUpd contributor)
        {
            HttpResponseMessage response = null;
            try
            {
                SofETest.Models.Contributor c = Services.Contributors.Get(contributor.Id);
                Mapper.CreateMap<ContributorUpd, SofETest.Models.Contributor>();
                Mapper.Map<ContributorUpd, SofETest.Models.Contributor>(contributor, c);

                Services.Contributors.Update(c);
                response = Request.CreateResponse(HttpStatusCode.OK, contributor);
                string uri = Url.Route(null, new { id = c.Id });
                response.Headers.Location = new Uri(Request.RequestUri, uri);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("\r\n", "\r\n ");
                response = new HttpResponseMessage(HttpStatusCode.Conflict);
                response.Headers.Add("Error-Description", msg);
            }
            return response;       
        }

        // DELETE api/contributors/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = null;
            try
            {
                SofETest.Models.Contributor contributor = Services.Contributors.Get(id);
                Services.Contributors.Delete(contributor);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("\r\n", "\r\n ");
                response = new HttpResponseMessage(HttpStatusCode.Conflict);
                response.Headers.Add("Error-Description", msg);
            }
            return response;       
        }
    }
}
