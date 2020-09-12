using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Converters;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CalenderLogic
  {

    public static List<CalenderDto> SelectAdminParentMeetings()
    {
      int year = PublicLogic.CalcBeaginYear().Year;
      List<CalenderDto> parentsMeetings = new List<CalenderDto>();
      using (TafToTafEntities db=new TafToTafEntities())
      {
        var meetings = db.Calanders.Where(c => c.KindId == 3&&DateTime.Now.Month-c.dateStart.Value.Month<=2&&c.dateStart.Value.Year==year).ToList();
        foreach (var calander in meetings)
        {
          parentsMeetings.Add(BLL.Converters.CalanderC.ToCalanderDto(calander));
        }
      }
      return parentsMeetings;
    }
    public static List<CalenderDto> SelectAdminTeamMeetings()
    {
      int year = PublicLogic.CalcBeaginYear().Year;
      List<CalenderDto> teamMeetings = new List<CalenderDto>();
      using (TafToTafEntities db = new TafToTafEntities())
      {
        var meetings = db.Calanders.Where(c => c.KindId == 2
 && DateTime.Now.Month - c.dateStart.Value.Month <= 2 && c.dateStart.Value.Year == year).ToList();
        foreach (var calander in meetings)
        {
          teamMeetings.Add(BLL.Converters.CalanderC.ToCalanderDto(calander));
        }
      }
      return teamMeetings;
    }
    public static List<CalenderDto> SelectCalendarKinderGarden(int kinderGardenID)
    {
      int year = PublicLogic.CalcBeaginYear().Year;
      List<CalenderDto> calenderDtos = new List<CalenderDto>();
      using (TafToTafEntities db=new TafToTafEntities())
      {
        var calenders = db.Calanders.Where(c => c.KinderGardenId == kinderGardenID && c.dateStart.Value.Year == year);
        foreach (var calander in calenders)
        {
          calenderDtos.Add(CalanderC.ToCalanderDto(calander));
        }
      }
      return calenderDtos;
    }
  }
}
