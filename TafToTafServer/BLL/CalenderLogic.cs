using BLL;
using BLL.Converters;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class CalenderLogic
  {
    private static int year = PublicLogic.CalcBeaginYear().Year;

    public static List<CalenderDto> SelectAdminParentMeetings()
    {
      int year = PublicLogic.CalcBeaginYear().Year;
      List<CalenderDto> parentsMeetings = new List<CalenderDto>();
      using (TafToTafEntities2 db = new TafToTafEntities2())
      {
        var meetings = db.Calanders.Where(c => c.KindId == 5 && DateTime.Now.Month - c.DateStart.Value.Month <= 2 && c.DateStart.Value.Year == year).ToList();
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
      using (TafToTafEntities2 db = new TafToTafEntities2())
      {
        var meetings = db.Calanders.Where(c => c.KindId == 4
 && DateTime.Now.Month - c.DateStart.Value.Month <= 2 && c.DateStart.Value.Year == year).ToList();
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
      using (TafToTafEntities2 db = new TafToTafEntities2())
      {
        var calenders = db.Calanders.Where(c => c.KindId<4&& c.KinderGardenId == kinderGardenID && c.DateStart.Value.Year == year);
        foreach (var calander in calenders)
        {
          calenderDtos.Add(CalanderC.ToCalanderDto(calander));
        }
      }
      return calenderDtos;
    }
    public static List<CalenderDto> SelectCalenderChild(int childId)//מקבלת קוד ילד ומחזירה את כל הטיפולים שלן
    {
      using (TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var child = db.Children.FirstOrDefault(ch => ch.Id == childId);
        if (child == null)
        {
          return null;
        }
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        var Treatments = db.Calanders.Where(tret => tret.KindId <4 && tret.DateStart.Value.Year ==year  && tret.ChildId == childId).ToList();
        foreach (var calender in Treatments)
        {
          CalenderList.Add(CalanderC.ToCalanderDto(calender));
        }
        return CalenderList;
      }
    }
    public static List<CalenderDto> SelectCalenderWorker(int workerId)//מקבלת קוד עובדת ומחזירה את כל הטיפולים שלה ואת הישיבות צוות והורים
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var worker = db.Professionals.FirstOrDefault(p => p.Id == workerId);
        if (worker == null)
        {
          return null;
        }
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        var Treatments = db.Calanders.Where(tret => tret.KindId <4 && tret.DateStart.Value.Year == year && tret.ProfessionalId == workerId).ToList();
        CalenderList.AddRange(SelectWorkerTeamMeeting(workerId));
        CalenderList.AddRange(SelectWorkerParentsMeeting(workerId));
        foreach (var calender in Treatments)
        {
          CalenderList.Add(CalanderC.ToCalanderDto(calender));
        }
        return CalenderList;
      }

    }
    public static List<CalenderDto> SelectWorkerParentsMeeting(int workerId)//מפגשי הורים לעובדת
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        List<KinderGardenDto> listKnd = KinderGardenLogic.SelectWorkersKinderGardens(workerId);
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        List<DAL.Calander> MeetingParents = new List<DAL.Calander>();
        foreach (var knd in listKnd)
        {
          MeetingParents.AddRange(db.Calanders.Where(meetParent => meetParent.KindId == 5 && meetParent.DateStart.Value.Year == year
          && DateTime.Now.Month - meetParent.DateStart.Value.Month <= 2 && meetParent.KinderGardenId == knd.Id).ToList());
        }
        foreach (var calender in MeetingParents)
        {
          CalenderList.Add(CalanderC.ToCalanderDto(calender));
        }
        return CalenderList;
      }
    }
    public static List<CalenderDto> SelectWorkerTeamMeeting(int workerId)//מפגשי צוות לעובדת
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        List<KinderGardenDto> listKnd = KinderGardenLogic.SelectWorkersKinderGardens(workerId);
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        List<DAL.Calander> Meetings = new List<DAL.Calander>();
        foreach (var knd in listKnd)
        {
          Meetings.AddRange(db.Calanders.Where(meet => meet.KindId == 4 && meet.DateStart.Value.Year == year
          && DateTime.Now.Month - meet.DateStart.Value.Month <= 2 && meet.KinderGardenId == knd.Id).ToList());
        }
        foreach (var calender in Meetings)
        {
          CalenderList.Add(CalanderC.ToCalanderDto(calender));
        }
        return CalenderList;
      }
    }
    public static List<CalenderDto> SelectChildParentMeeting(int childId)//מפגשי הורים לילד
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var child = db.Children.FirstOrDefault(ch => ch.Id == childId);
        if (child == null)
        {
          return null;
        }
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        var childknd = db.ChildKinderGardens.FirstOrDefault(knd => knd.ChildID == childId);
        var meetParent = db.Calanders.Where(meet => meet.KindId == 5 && meet.DateStart.Value.Year == year && meet.KinderGardenId == childknd.KindrGardenID &&  meet.ChildId==child.Id).ToList();
        foreach (var calender in meetParent)
        {
          CalenderList.Add(CalanderC.ToCalanderDto(calender));
        }
        return CalenderList;
      }
    }
  }
}




