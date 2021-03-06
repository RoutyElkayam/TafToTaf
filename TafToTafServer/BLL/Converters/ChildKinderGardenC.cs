using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
   
        public class ChildKinderGardenC
        {
            public static ChildKinderGardenDto ToChildKinderGardenDto(ChildKinderGarden childKinderGarden)
            {
                ChildKinderGardenDto childKinderGardenDto = new ChildKinderGardenDto()
                {
                    Id = childKinderGarden.Id,
                    ChildID = childKinderGarden.ChildID.GetValueOrDefault(),
                    BeginYear = childKinderGarden.BeginYear.GetValueOrDefault(),
                    EndYear = childKinderGarden.EndYear.GetValueOrDefault(),
                    KindrGardenID = childKinderGarden.KindrGardenID.GetValueOrDefault()

                };
                return childKinderGardenDto;
            }
            public static ChildKinderGarden ToChildKinderGarden(ChildKinderGardenDto childKinderGardenDto)
            {
                ChildKinderGarden childKinderGarden = new ChildKinderGarden()
                {
                    Id = childKinderGardenDto.Id,
                    ChildID = childKinderGardenDto.ChildID,
                    BeginYear = childKinderGardenDto.BeginYear,
                    EndYear = childKinderGardenDto.EndYear,
                    KindrGardenID = childKinderGardenDto.KindrGardenID

                };
                return childKinderGarden;
            }
        }
}
