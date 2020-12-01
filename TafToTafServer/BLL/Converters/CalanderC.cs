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

    public static CalenderDto ToCalanderDto(Calander calander)
    {
      CalenderDto calanderDto = new CalenderDto()
      {
        Id = calander.Id,
        End = calander.DateEnd.GetValueOrDefault(),
        Start = calander.DateStart.GetValueOrDefault(),
        KindId = calander.KindId.GetValueOrDefault(),
        //KinderGardenId = calander.KinderGardenId.GetValueOrDefault(),
        //ProfessionalId = calander.ProfessionalId.GetValueOrDefault(),
        //ChildID = calander.ChildId.GetValueOrDefault(),
        Title = calander.NameMeeting
      };    
     return calanderDto;
    }
    public static Calander ToCalanderDal(CalenderDto calanderDto)
    {
      Calander calander = new Calander()
      {
        Id = calanderDto.Id,
        DateStart = calanderDto.Start,
        DateEnd = calanderDto.End,
        //KindId = calanderDto.KindId,
        //KinderGardenId = calanderDto.KinderGardenId,
        //ProfessionalId = calanderDto.ProfessionalId,
        //ChildId = calanderDto.ChildID,
        NameMeeting = calanderDto.Title,
      };
      return calander;
    }
  }
}

