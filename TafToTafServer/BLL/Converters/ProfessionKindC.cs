using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class ProfessionKindC
    {
        public ProfessionKindDto ToProfessionKindDto(ProfessionKind professionKind)
        {
            ProfessionKindDto professionKindDto = new ProfessionKindDto()
            {
                Id = professionKind.Id,
                Name = professionKind.Name
            };
            return professionKindDto;
        }
        public ProfessionKind ToProfessionKind(ProfessionKindDto professionKindDto)
        {
            ProfessionKind professionKind = new ProfessionKind()
            {
                Id = professionKindDto.Id,
                Name = professionKindDto.Name
            };
            return professionKind;
        }
    }
}
