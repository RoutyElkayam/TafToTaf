using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public static class UserC
    {
        public static UserDto ToUserDto(User user)
        {
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Tel = user.Tel,
                Phone = user.Phone,
                UserName = user.UserName,
                Password = user.Password,
                KindUser = (int)user.KindUser
            };
            return userDto;
        }
        public static User ToUser(UserDto userDto)
        {
            User user = new User()
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Tel = userDto.Tel,
                Phone = userDto.Phone,
                UserName = userDto.UserName,
                Password = userDto.Password,
                KindUser = userDto.KindUser
            };
            return user;
        }
    }
}
