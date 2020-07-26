using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  [RoutePrefix("api/Child")]
  public class ChildController : ApiController
  {
    [HttpGet]
    // GET: api/Child
    public IHttpActionResult Get()
    {
      try
      {
        List<ChildDto> children = ChildLogic.SelectChildren();
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
    [HttpGet]
    // GET: api/Child/5
    public IHttpActionResult Get(int id)
    {
      try
      {
        var child = ChildLogic.SelectChild(id);
        if(child!=null)
        {
          return Ok(child);
        }
        return BadRequest("null result");
      }
      catch(HttpListenerException ex)
      {
        return BadRequest(ex.Message);
      }
      catch(Exception ex)
      {
        return BadRequest(ex.Message);
      }

    }
    [HttpPost]
    // POST: api/Child
    public void Post([FromBody]ChildDto child)
    {
      try
      {
        ChildLogic.InsertChild(child);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
   [HttpPut]
    // PUT: api/Child/5
    public void Put(int id, [FromBody]string value)
    {

    }
    [HttpDelete]
    // DELETE: api/Child/5
    public IHttpActionResult Delete(int id)
    {
      try
      {
        ChildLogic.DeleteChild(id);
        return Ok();
      }
      catch (Exception ex)
      {

        return BadRequest(ex.InnerException.InnerException.Message);
      }
    }
  }
}
