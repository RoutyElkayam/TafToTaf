using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class ProfessionalC
    {
        public static DTO.ProfessionalDTO ToProfessionalDto(Professional professional)
        {
            ProfessionalDTO professionalDto = new ProfessionalDTO()
            {
                Id = professional.Id,
                Name = professional.Name,
                NumHourWork = professional.NumHourWork.GetValueOrDefault(),
                ProfessionKind = professional.ProfessionKind.GetValueOrDefault(),
                Sunday = professional.Sunday.GetValueOrDefault(),
                Monday = professional.Monday.GetValueOrDefault(),
                Thuesday = professional.Thuesday.GetValueOrDefault(),
                Tursday = professional.Tursday.GetValueOrDefault(),
                Wednesday = professional.Wednesday.GetValueOrDefault()
            };
            return professionalDto;
        }
        public static Professional ToProfessional(ProfessionalDTO professionalDto)
        {
            Professional professional = new Professional()
            {
                Id = professionalDto.Id,
                Name = professionalDto.Name,
                NumHourWork = professionalDto.NumHourWork,
                ProfessionKind = professionalDto.ProfessionKind,
                Sunday = professionalDto.Sunday,
                Monday = professionalDto.Monday,
                Thuesday = professionalDto.Thuesday,
                Tursday = professionalDto.Tursday,
                Wednesday = professionalDto.Wednesday
            };
            return professional;
        }

    }
}
