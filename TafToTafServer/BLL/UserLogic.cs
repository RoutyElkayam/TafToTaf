using BLL.Converters;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLogic
    {
        public static UserDto Login(string username,string password)
        {
            using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
            {
                var user= db.Users.FirstOrDefault(p => p.UserName == username && p.Password == password);
                if (user == null)
                    return null;
              return  UserC.ToUserDto(user);
            }
        }
    }
}
