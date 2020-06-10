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
            public ChildKinderGardenDto ToChildKinderGardenDto(ChildKinderGarden childKinderGarden)
            {
                ChildKinderGardenDto childKinderGardenDto = new ChildKinderGardenDto()
                {
                    Id = childKinderGarden.Id,
                    ChildID = (int)childKinderGarden.ChildID,
                    BeginYear = (DateTime)childKinderGarden.BeginYear,
                    EndYear = (DateTime)childKinderGarden.EndYear,
                    EntitlementID = (int)childKinderGarden.EntitlementID,
                    KindrGardenID = (int)childKinderGarden.KindrGardenID

                };
                return childKinderGardenDto;
            }
            public ChildKinderGarden ToChildKinderGarden(ChildKinderGardenDto childKinderGardenDto)
            {
                ChildKinderGarden childKinderGarden = new ChildKinderGarden()
                {
                    Id = childKinderGardenDto.Id,
                    ChildID = childKinderGardenDto.ChildID,
                    BeginYear = childKinderGardenDto.BeginYear,
                    EndYear = childKinderGardenDto.EndYear,
                    EntitlementID = childKinderGardenDto.EntitlementID,
                    KindrGardenID = childKinderGardenDto.KindrGardenID

                };
                return childKinderGarden;
            }
        }
}
