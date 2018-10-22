using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Readify.Controllers
{
    public class TriangleTypeController : ApiController
    {
        [ResponseType(typeof (string))]
        public HttpResponseMessage Get(HttpRequestMessage request, string a, string b, string c)
        {
            if (int.Parse(a) <= 0 || int.Parse(b) <= 0 || int.Parse(c) <= 0)
            {
                return request.CreateResponse(HttpStatusCode.OK, "Error");
            }

            var result = GetTriangleType(int.Parse(a), int.Parse(b), int.Parse(c));
            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        private static string GetTriangleType(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return "Error";
            }

            var values = new[] { a, b, c };

            if (AllThreeSidesAreEqual(values))
            {
                return "Equilateral";
            }

            if (TwoSidesAreEqual(values))
            {
                return "Isosceles";
            }

            return NoSidesAreEqual(values) ? "Scalene" : "Error";
        }

        private static bool AllThreeSidesAreEqual(IEnumerable<int> values)
        {
            return values.Distinct().Count() == 1;
        }

        private static bool TwoSidesAreEqual(IEnumerable<int> values)
        {
            return values.Distinct().Count() == 2;
        }

        private static bool NoSidesAreEqual(IEnumerable<int> values)
        {
            return values.Distinct().Count() == 3;
        }
    }
}