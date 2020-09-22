using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  [RoutePrefix("api/Professional")]
  public class ProfessionalController : ApiController
    {
    [HttpGet]
    // GET: api/Child
    public IHttpActionResult Get()
    {
      try
      {
        List<ProfessionalDTO> professionals = ProffessionalLogic.SelectProffesionals();
        return Ok(professionals);
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
    // GET: api/Proffesional/5
    public IHttpActionResult Get(int id)
    {
      try
      {
        var proffesional = ProffessionalLogic.SelectProfessional(id);
        if (proffesional == null)
        {
          return BadRequest("null result");

        }
        return Ok(proffesional);
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
    [HttpGet]
    [Route("ProffesionalUserId/{id}")]

    public IHttpActionResult GetProffesionalUserId(int id)
    {
      try
      {
        var proffesionalId = ProffessionalLogic.SelectProfessionalByUserID(id);
        if (proffesionalId==null)
        {
          return BadRequest("null result");

        }
        return Ok(proffesionalId);

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
    [HttpPost]
    public IHttpActionResult Post([FromBody]ProffessionalPost professional)
    {
      try
      {
        ProffessionalLogic.InsertProffesional(professional);
        return Ok();
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
    public IHttpActionResult Put(int id, [FromBody]ProfessionalDTO professional)
    {
      try
      {
        if (professional != null)
        {
          ProffessionalLogic.EditProffesional(id, professional);
          return Ok("nicly");
        }
        return BadRequest();
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
    // DELETE: api/Proffesional/5
    public IHttpActionResult Delete(int id)
    {
      try
      {
        ProffessionalLogic.DeleteProffesional(id);
        return Ok("deleted");
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
