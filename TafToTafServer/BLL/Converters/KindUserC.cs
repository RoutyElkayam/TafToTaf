using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class KindUserC
    {
        public DTO.KindUserDto ToKindUserDto(DAL.KindUser kindUser)
        {
            DTO.KindUserDto kindUserDto = new KindUserDto()
            {
                Id = kindUser.Id,
                Name = kindUser.Name
            };
            return kindUserDto;
        }
        public DAL.KinderGarden ToKinderGardenDal(DTO.KinderGardenDto kinderGardenDto)
        {
            DAL.KinderGarden kinderGarden = new KinderGarden()
            {
                Id = kinderGardenDto.Id,
                Code = kinderGardenDto.Code,
                Name = kinderGardenDto.Name
            };
            return kinderGarden;
        }
    }
}
