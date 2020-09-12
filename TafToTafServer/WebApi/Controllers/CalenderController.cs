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
  [RoutePrefix("api/Calender")]
  public class CalenderController : ApiController
  {
    [HttpGet]
    [Route("CalenderChild/{id}")]
    // GET: api/Calender/CalenderChild/2
    public IHttpActionResult GetcalenderChild(int id)
    {
      try
      {
        List<CalenderDto> calenderChild = CalenderLogic.SelectCalenderChild(id);
        return Ok(calenderChild);
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
    [Route("CalenderWorker/{id}")]
    public IHttpActionResult GetcalenderWorker(int id)
    {
      try
      {
        List<CalenderDto> calenderWorker = CalenderLogic.SelectCalenderWorker(id);
        return Ok(calenderWorker);
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
    [Route("ChildParentMeeting/{id}")]
    public IHttpActionResult GetChildParentMeeting(int id)
    {
      try
      {
        List<CalenderDto> childParentMeeting = CalenderLogic.SelectChildParentMeeting(id);
        return Ok(childParentMeeting);
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
    [Route("TeamMeeting/{id}")]
    public IHttpActionResult GetTeamMeeting(int id)
    {
      try
      {
        List<CalenderDto> teamMeeting = CalenderLogic.SelectTeamMeeting(id);
        return Ok(teamMeeting);
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
    [Route("WorkerParentsMeeting/{id}")]
    public IHttpActionResult GetWorkerParentsMeeting(int id)
    {
      try
      {
        List<CalenderDto> workerParentsMeeting = CalenderLogic.SelectWorkerParentsMeeting(id);
        return Ok(workerParentsMeeting);
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
  }

}
