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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        // GET: api/Users
        public IHttpActionResult GetUser()
        {
            UserDto userDto = new UserDto() { FirstName = "Elchanan", KindUser = 2, Password = "211550231" };
            if (userDto != null)
                return Ok(userDto);
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(UserLogin userLogin)
        {
            try
            {
                var user = UserLogic.Login(userLogin.UserName, userLogin.Password);
                if (user != null)
                    return Ok(user);
                return BadRequest();
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
