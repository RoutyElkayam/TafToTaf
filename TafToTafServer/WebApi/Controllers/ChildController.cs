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
        if (child == null)
        {
          return BadRequest("null result");

        }
        return Ok(child);
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
    [HttpPost]

    // POST: api/Child/kinderGardenName
    public IHttpActionResult Post([FromBody]ChildDto child, [FromUri]string id)
    {
      try
      {
        ChildLogic.InsertChild(child, id);
        return Ok("nice");
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
    [HttpPut]
    // PUT: api/Child/5
    public IHttpActionResult Put(int id, [FromBody]ChildDto child)
    {
      try
      {
        if (child != null)
        {
          ChildLogic.EditChild(id, child);
          return Ok("nicly");
        }
        return BadRequest("object to edit must have values");
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
    [HttpDelete]
    // DELETE: api/Child/5
    public IHttpActionResult Delete(int id)
    {
      try
      {
        ChildLogic.DeleteChild(id);
        return Ok("deleted");
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
