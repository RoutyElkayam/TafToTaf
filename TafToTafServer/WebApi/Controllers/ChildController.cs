using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ChildController : ApiController
    {
        // GET: api/Child
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Child/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Child
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Child/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Child/5
        public void Delete(int id)
        {
        }
    }
}
