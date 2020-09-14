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

    // GET: api/Calender/ChildCalendar
    [HttpGet]
  [Route("AdminParentMeetings")]
    public IHttpActionResult GetAdminParentMeetings()
    {
      try
      {
        List<CalenderDto> adminParentMeetings = CalenderLogic.SelectAdminParentMeetings();
        return Ok(adminParentMeetings);
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
  [Route("AdminTeamMeetings")]
    public IHttpActionResult GetAdminTeamMeetings()
    {
      try
      {
        List<CalenderDto> AdminTeamMeetings = CalenderLogic.SelectAdminTeamMeetings();
        return Ok(AdminTeamMeetings);
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
   [Route("CalendarKinderGarden/{id}")]
    public IHttpActionResult GetCalendarKinderGarden(int id)
    {
      try
      {
        List<CalenderDto> CalendarKinderGarden = CalenderLogic.SelectCalendarKinderGarden(id);
        return Ok(CalendarKinderGarden);
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
    [Route("WorkerTeamMeeting/{id}")]
    public IHttpActionResult GetTeamMeeting(int id)
    {
      try
      {
        List<CalenderDto> teamMeeting = CalenderLogic.SelectWorkerTeamMeeting(id);
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

