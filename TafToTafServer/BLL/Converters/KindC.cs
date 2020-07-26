using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
        public class KindC
        {
            public static KindDto ToKindDto(Kind kind)
            {
                KindDto kindDto = new KindDto()
                {
                    Id = kind.Id,
                    Name = kind.Name
                };
                return kindDto;
            }
            public static Kind ToKind(KindDto kindDto)
            {
                Kind kind = new Kind()
                {
                    Id = kindDto.Id,
                    Name = kindDto.Name
                };
                return kind;
            }

        }
    
}
