using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json.Linq;

namespace SofETest.WebAPI.Filters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// This method is executed for every controller that is decorated with this custom attribute. 
        /// It will validate the model with the MVC validation conventions (decorations) and will form a JSON object with the errors.
        /// It will set the context response in case model is not valid. 
        /// </summary>
        /// <param name="context">context of the action of the controller.</param>
        public override void OnActionExecuting(HttpActionContext context)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                //Using Json object because maybe in the release version of MVC 4 the Json object will be supported again and will appear in the body of the response.
                JObject errors = new JObject();
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors.Any())
                    {
                        string msg = state.Errors.First().ErrorMessage;
                        if(msg != string.Empty)
                        {
                            errors[key] = msg;
                        }
                    }
                }

                HttpResponseMessage response = context.Request.CreateResponse<JObject>(HttpStatusCode.BadRequest, errors);
                response.Headers.Add("Error-Description", "Model contains errors");
                context.Response = response;
            }
        }
    }
}