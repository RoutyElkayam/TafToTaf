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
    [HttpGet]
    // GET: api/ChildKinderarden
    public IHttpActionResult GetKinderGNameOfChild()
    {
      try
      {
        var queryString = Request.GetQueryNameValuePairs();
        if (queryString == null)
          return BadRequest("null query string");
        string kGardenName = BLL.ChildKinderGardenLogic.GetKinderGardenOfChild(int.Parse(queryString.First(kv=>kv.Key=="ChildID").Value));
        return Ok(kGardenName);
      }
      catch (HttpListenerException ex)
      {
        return BadRequest(ex.InnerException.Message);
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }
    }


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
