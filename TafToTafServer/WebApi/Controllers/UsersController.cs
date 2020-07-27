using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;

namespace WebApi.Controllers
{
  
  [RoutePrefix("api/Users")]
  public class UsersController : ApiController
  {
    [HttpGet]
    // GET: api/Users
    public IHttpActionResult GetUser()
    {
      try
      {
        UserDto userDto = UserLogic.isLoggedIn(Request.Headers.GetValues("Authorization").First());
        if (userDto != null)
          return Ok(userDto);
        return BadRequest("Unauthorized");
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
    [Route("login")]
    public IHttpActionResult Login([FromBody]UserLogin userLogin)
    {
      try
      {
        var user = UserLogic.Login(userLogin.UserName, userLogin.Password);
        if (user != null)
          return Ok(TokenLogic.EncodeToken(user.Id));
        return BadRequest("UserName or pasword are not valid");
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


    // GET: api/Users/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Users
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Users/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Users/5
    public void Delete(int id)
    {
    }
  }
}
