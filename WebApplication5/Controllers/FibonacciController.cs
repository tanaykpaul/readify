using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication5;

namespace Readify.Controllers
{
    public class FibonacciController : ApiController
    {
        [ResponseType(typeof(long))]
        public HttpResponseMessage Get(HttpRequestMessage request, long n)
        {
            var result = GetNthFibonacci(n);

            return result < 0 ? 
                new HttpResponseMessage(HttpStatusCode.BadRequest) : 
                request.CreateResponse(HttpStatusCode.OK, result);
        }

        private static long GetNthFibonacci(long n)
        {
            if (n < 0)
            {
                n = -1 * n;
            }

            if (n < Constants.FibonacciList.Count)
            {
                return Constants.FibonacciList[unchecked((int)n)];
            }

            var firstSeq = Constants.FibonacciList[unchecked((Constants.FibonacciList.Count - 2))];
            var secondSeq = Constants.FibonacciList[unchecked((Constants.FibonacciList.Count - 1))];

            for (var i = Constants.FibonacciList.Count - 1; i < n; i++)
            {
                var temp = firstSeq;
                firstSeq = secondSeq;
                secondSeq = temp + secondSeq;
                if (secondSeq < 0)
                {
                    return secondSeq;
                }

                Constants.FibonacciList.Add(secondSeq);
            }

            return Constants.FibonacciList[unchecked((int)n)];
        }
    }
}