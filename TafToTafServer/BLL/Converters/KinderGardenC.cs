using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public static class KinderGardenC
    {
        public static KinderGardenDto ToKinderGardenDto(KinderGarden kinderGarden)
        {
            KinderGardenDto kinderGardenDto = new KinderGardenDto()
            {
                Id = kinderGarden.Id,
                Code = kinderGarden.Code,
                Name = kinderGarden.Name
            };
            return kinderGardenDto;
        }
        public static DAL.KinderGarden ToKinderGardenDal(DTO.KinderGardenDto kinderGardenDto)
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
