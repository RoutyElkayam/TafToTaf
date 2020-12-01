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
      using (TafToTafEntities1 db = new TafToTafEntities1())
      {
        var meetings = db.Calanders.Where(c => c.KindId == 3 && DateTime.Now.Month - c.DateStart.Value.Month <= 2 && c.DateStart.Value.Year == year).ToList();
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
      using (TafToTafEntities1 db = new TafToTafEntities1())
      {
        var meetings = db.Calanders.Where(c => c.KindId == 2
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
      using (TafToTafEntities1 db = new TafToTafEntities1())
      {
        var calenders = db.Calanders.Where(c => c.KinderGardenId == kinderGardenID && c.DateStart.Value.Year == year);
        foreach (var calander in calenders)
        {
          calenderDtos.Add(CalanderC.ToCalanderDto(calander));
        }
      }
      return calenderDtos;
    }
    public static List<CalenderDto> SelectCalenderChild(int childId)//מקבלת קוד ילד ומחזירה את כל הטיפולים שלן
    {
      using (TafToTafEntities1 db = new DAL.TafToTafEntities1())
      {
        var child = db.Children.FirstOrDefault(ch => ch.Id == childId);
        if (child == null)
        {
          return null;
        }
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        var Treatments = db.Calanders.Where(tret => tret.KindId == 1 && tret.DateStart.Value.Year ==year  && tret.ChildId == childId).ToList();
        foreach (var calender in Treatments)
        {
          CalenderList.Add(CalanderC.ToCalanderDto(calender));
        }
        return CalenderList;
      }
    }
    public static List<CalenderDto> SelectCalenderWorker(int workerId)//מקבלת קוד עובדת ומחזירה את כל הטיפולים שלה ואת הישיבות צוות והורים
    {
      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
      {
        var worker = db.Professionals.FirstOrDefault(p => p.Id == workerId);
        if (worker == null)
        {
          return null;
        }
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        var Treatments = db.Calanders.Where(tret => tret.KindId == 1 && tret.DateStart.Value.Year == year && tret.ProfessionalId == workerId).ToList();
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
      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
      {
        List<KinderGardenDto> listKnd = KinderGardenLogic.SelectWorkersKinderGardens(workerId);
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        List<DAL.Calander> MeetingParents = new List<DAL.Calander>();
        foreach (var knd in listKnd)
        {
          MeetingParents.AddRange(db.Calanders.Where(meetParent => meetParent.KindId == 3 && meetParent.DateStart.Value.Year == year
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
      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
      {
        List<KinderGardenDto> listKnd = KinderGardenLogic.SelectWorkersKinderGardens(workerId);
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        List<DAL.Calander> MeetingParents = new List<DAL.Calander>();
        foreach (var knd in listKnd)
        {
          MeetingParents.AddRange(db.Calanders.Where(meet => meet.KindId == 2 && meet.DateStart.Value.Year == year
          && DateTime.Now.Month - meet.DateStart.Value.Month <= 2 && meet.KinderGardenId == knd.Id).ToList());
        }
        foreach (var calender in MeetingParents)
        {
          CalenderList.Add(CalanderC.ToCalanderDto(calender));
        }
        return CalenderList;
      }
    }
    public static List<CalenderDto> SelectChildParentMeeting(int childId)//מפגשי הורים לילד
    {
      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
      {
        var child = db.Children.FirstOrDefault(ch => ch.Id == childId);
        if (child == null)
        {
          return null;
        }
        List<CalenderDto> CalenderList = new List<CalenderDto>();
        var childknd = db.ChildKinderGardens.FirstOrDefault(knd => knd.ChildID == childId);
        var meetParent = db.Calanders.Where(meet => meet.KindId == 3 && meet.DateStart.Value.Year == year && meet.KinderGardenId == childknd.KindrGardenID).ToList();
        foreach (var calender in meetParent)
        {
          CalenderList.Add(CalanderC.ToCalanderDto(calender));
        }
        return CalenderList;
      }
    }
  }
}




