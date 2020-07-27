using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{  
        public class ChildC
        {
            public static ChildDto ToChildDTO(Child child)
            {
                ChildDto childDto = new ChildDto()
                {
                    Id = child.Id,
                    Tz = child.Tz,
                    FirstName = child.FirstName,
                    LastName = child.LastName,
                    BornDate = (DateTime) child.BornDate,
                    NumHoursConfirm=(double)child.NumHoursConfirm,
                    ParentID = (int)child.ParentID
                };
                return childDto;
            }
            public static Child  ToChildDAL(ChildDto childDto)
            {
                Child child = new Child()
                {
                    Id = childDto.Id,
                    Tz = childDto.Tz,
                    FirstName = childDto.FirstName,
                    LastName = childDto.LastName,
                    BornDate = childDto.BornDate,
                    NumHoursConfirm=childDto.NumHoursConfirm,
                    ParentID = childDto.ParentID
                };
                return child;
            }
        }
}
