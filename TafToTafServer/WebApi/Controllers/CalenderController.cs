using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CalenderController : ApiController
    {
        // GET: api/Calender
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Calender/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Calender
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Calender/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Calender/5
        public void Delete(int id)
        {
        }
    }
}
