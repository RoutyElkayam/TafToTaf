using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Converters
{
    public class CalanderC
    {
        public  CalenderDto ToCalanderDto(Calander calander)
        {
            CalenderDto calanderDto = new CalenderDto()
            {
                Id = calander.Id,
                Date = (DateTime)calander.Date,
                KindId = (int)calander.KindId,
                KinderGardenId = (int)calander.KinderGardenId,
                ProfessionalId = (int)calander.ProfessionalId

            };
            return calanderDto;
        }
        public Calander ToCalanderDal(CalenderDto calanderDto)
        {
            Calander calander = new Calander()
            {
                Id = calanderDto.Id,
                Date = calanderDto.Date,
                KindId = calanderDto.KindId,
                KinderGardenId = calanderDto.KinderGardenId,
                ProfessionalId = calanderDto.ProfessionalId
            };
            return calander;
        }
    }
}

