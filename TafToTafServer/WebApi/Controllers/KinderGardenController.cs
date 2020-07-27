using BLL;
using DTO;
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
    [HttpGet]
    // GET: api/KinderGarden
    public IHttpActionResult Get()
    {
      try
      {
        List<KinderGardenDto> kinderGardens = KinderGardenLogic.SelectKinderGardens();
        return Ok(kinderGardens);
      }
      catch(HttpListenerException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
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
