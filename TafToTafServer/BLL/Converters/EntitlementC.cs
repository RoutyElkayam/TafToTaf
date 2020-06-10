using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{ 
        public class EntitlementC
        {
            public EntitlementDto ToEntitlementDto(Entitlement entitlement)
            {
                EntitlementDto entitlementDto = new EntitlementDto()
                {
                    Id = entitlement.Id,
                    NumHour = entitlement.NumHour,
                    ProfessionId = (int)entitlement.ProfessionId
                };
                return entitlementDto;
            }
            public Entitlement ToEntitlement(EntitlementDto entitlementDto)
            {
                Entitlement entitlement = new Entitlement()
                {
                    Id = entitlementDto.Id,
                    NumHour = entitlementDto.NumHour,
                    ProfessionId = entitlementDto.ProfessionId
                };
                return entitlement;
            }
        }
}
