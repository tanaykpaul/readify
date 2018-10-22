using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication5;

namespace Readify.Controllers
{
    public class TokenController : ApiController
    {
        [ResponseType(typeof(Guid))]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.OK, new Guid(Constants.CandidateId));
        }
    }
}