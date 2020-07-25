using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    public UserLogin(string userName,string password)
    {
      this.UserName = userName;
      this.Password = password;
    }
    }
}
