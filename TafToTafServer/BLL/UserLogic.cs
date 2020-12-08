using BLL.Converters;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Net.Mail;
namespace BLL
{
  public class UserLogic
  {
    public static UserDto IsLoggedIn(string token)
    {

      int idUser = TokenLogic.DecodeToken(token);
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var user = db.Users.FirstOrDefault(u => u.Id == idUser);
        if (user == null)
          return null;
        return UserC.ToUserDto(user);
      }
    }
    public static UserDto Login(string username, string password)
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var user = db.Users.FirstOrDefault(p => p.UserName == username && p.Password == password);
        if (user == null)
          return null;
        return UserC.ToUserDto(user);
      }
    }
    //public void Send(System.Net.Mail.MailMessage message);
  }
}
