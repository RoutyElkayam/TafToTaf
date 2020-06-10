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
            public ChildDto ToChildDTO(Child child)
            {
                ChildDto childDto = new ChildDto()
                {
                    Id = child.Id,
                    Tz = child.Tz,
                    FirstName = child.FirstName,
                    LastName = child.LastName,
                    BornDate = (DateTime) child.BornDate
                };
                return childDto;
            }
            public Child ToChildDAL(ChildDto childDto)
            {
                Child child = new Child()
                {
                    Id = childDto.Id,
                    Tz = childDto.Tz,
                    FirstName = childDto.FirstName,
                    LastName = childDto.LastName,
                    BornDate = childDto.BornDate
                };
                return child;
            }
        }
}
