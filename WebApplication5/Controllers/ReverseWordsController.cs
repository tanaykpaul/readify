using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Readify.Controllers
{
    public class ReverseWordsController : ApiController
    {
        [ResponseType(typeof(string))]
        public HttpResponseMessage Get(HttpRequestMessage request, string sentence)
        {
            return request.CreateResponse(HttpStatusCode.OK, GetReverseWords(sentence));
        }

        private static string GetReverseWords(string sentense)
        {
            var items = sentense.Split(' ');
            var distinctItems = items.Distinct();
            sentense = distinctItems.Aggregate(sentense, (current, distinctItem) => current.Replace(distinctItem, Reverse(distinctItem)));

            return sentense;
        }

        private static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}