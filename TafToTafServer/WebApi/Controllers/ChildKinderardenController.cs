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
  [RoutePrefix("api/ChildKinderarden")]
  public class ChildKinderardenController : ApiController
  {
    [HttpGet]
    // GET: api/ChildKinderarden/kinderGardenName
    public IHttpActionResult GetChildren([FromUri]string id)
    {
      try
      {
        List<ChildDto> children = ChildKinderGardenLogic.GetChildrenInKinderGarden(id);
        return Ok(children);
      }
      catch (HttpListenerException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }
    }

    // GET: api/ChildKinderarden/5
    //public string Get(int id)
    //{
    //  return "value";
    //}

    // POST: api/ChildKinderarden
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/ChildKinderarden/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/ChildKinderarden/5
    public void Delete(int id)
    {
    }
  }
}
