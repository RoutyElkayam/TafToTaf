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
        public ProfessionalDto ToProfessionalDto(Professional professional)
        {
            ProfessionalDto professionalDto = new ProfessionalDto()
            {
                Id = professional.Id,
                Name = professional.Name,
                NumDaysWork = (int)professional.NumDaysWork,
                NumHourWork = (int)professional.NumHourWork,
                ProfessionKind = (int)professional.ProfessionKind,
                Sunday = (bool)professional.Sunday,
                Monday = (bool)professional.Monday,
                Thuesday = (bool)professional.Thuesday,
                Tursday = (bool)professional.Tursday,
                Wednesday = (bool)professional.Wednesday
            };
            return professionalDto;
        }
        public Professional ToProfessional(ProfessionalDto professionalDto)
        {
            Professional professional = new Professional()
            {
                Id = professionalDto.Id,
                Name = professionalDto.Name,
                NumDaysWork = professionalDto.NumDaysWork,
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
