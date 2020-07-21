using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class KinderGardenController : ApiController
    {
        // GET: api/KinderGarden
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/KinderGarden/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/KinderGarden
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/KinderGarden/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/KinderGarden/5
        public void Delete(int id)
        {
        }
    }
}
