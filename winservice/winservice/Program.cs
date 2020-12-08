using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugServiceCode
{
  public class TLTScheduler
  {

    private DateTime calcBeaginYear()
    {
      if (DateTime.Now.Month > 09)
        return new DateTime(DateTime.Now.Year, 09, 01);
      return new DateTime(DateTime.Now.Year - 1, 09, 01);

    }
    private void sortChidren(int profesionalKind, List<ChildDTO> children)
    {

      var child = children[0];
      if (profesionalKind == 2)
      {
        children[0] = children[1];
        children[1] = child;
      }
      else if (profesionalKind == 3)
      {
        children[0] = children[2];
        children[2] = child;
      }
    }

    //end
    public void WeeklyScheduleTLT()
    {
      //help variables
      DateTime thisDay;
      DateTime dateSchedule;
      DateTime date = calcBeaginYear();
      DateTime dateEnd;
      double numHoursScheduledToday;
      double childHours = 0;
      double NumHours;
      int numWindows;
      const double maxDailyNumHours = 4;//מקסימום 4 טיפולים ליום...
      List<ChildKinderGarden> sortedListChildren;
      List<ChildDTO> children = new List<ChildDTO>();
      List<string> daysWorkProfessional = new List<string>();//מס החלונות ליום העבודה הנל מאותחל ב0 לצורך הגבלה של חלון אחד בשבוע
      List<string> daysMeetingsProfessional = new List<string>();// ימים של פגישות שלה
      KinderGarden kinderGarden;
      //end

      using (TafToTafEntities db = new TafToTafEntities())
      {
        for (int professionKind = 1; professionKind < 4; professionKind++)
        {
          sortedListChildren = db.ChildKinderGardens.Where(ch => ch.BeginYear.Value == date).OrderBy(ch => ch.KindrGardenID).ToList();
          //במעבר מקלינאיות לפיזיותרפיסטיות וכדומה הריצה מתחדשת על רשימת כל הילדים בגנים
          foreach (var professional in db.Professionals)
          {
            numWindows = 0;
            if (daysWorkProfessional.Count() > 0)
              daysWorkProfessional.Clear();
            if (professional.ProfessionKind.Value == professionKind)
            {
              for (int i = 1; i <= 5; i++)
              {
                switch (i)
                {
                  case 1:
                    if (professional.Sunday.Value)
                      daysWorkProfessional.Add("Sunday");
                    break;
                  case 2:
                    if (professional.Monday.Value)
                      daysWorkProfessional.Add("Monday");
                    break;
                  case 3:
                    if (professional.Thuesday.Value)
                      daysWorkProfessional.Add("Tuesday");
                    break;
                  case 4:
                    if (professional.Wednesday.Value)
                      daysWorkProfessional.Add("Wednesday");
                    break;
                  case 5:
                    if (professional.Tursday.Value)
                      daysWorkProfessional.Add("Thursday");
                    break;
                }
              }
              if (children.Count() > 0)
                children.RemoveAll(ch => ch.Id != 0);
              //ריקון רשימת ילדים של עובדת קודמת לצורך הןספת ילדים לעובדת נוכחית
              NumHours = professional.NumHourWork.Value;
              //אתחול מספר השעות לעובדת לשעות שבועיות שלה
              for (int iCH = 0; iCH < sortedListChildren.Count(); iCH++)
              //הפסקות וישיבות?
              {
                if (NumHours <= 0)
                  break;
                int childID = sortedListChildren[iCH].ChildID.Value;
                var child = db.Children.FirstOrDefault(ch => ch.Id == childID);
                int kGardenId = sortedListChildren[iCH].KindrGardenID.Value;
                kinderGarden = db.KinderGardens.First(kG => kG.Id == kGardenId);
                if (child != null && daysWorkProfessional.Contains(kinderGarden.MeetingDay))
                  if (child.NumHoursConfirm.Value / 3 <= NumHours)//לא כולל הפסקה?
                  {
                    if (daysMeetingsProfessional.Contains(kinderGarden.MeetingDay) == false)
                      daysMeetingsProfessional.Add(kinderGarden.MeetingDay);
                    childHours = child.NumHoursConfirm.Value / 3;
                    children.Add(ChildDTO.ToChildDTO(child));//הוספת ילד בעל מספר שעות שמתאימות למסגרת  
                    NumHours -= childHours;//הפחתת מספר השעות שששובצו לעובדת
                    sortedListChildren.RemoveAt(iCH);//הסרת ילד מרשימה ממוינת כיוון ששובצה לו מטפלת
                    iCH--;//בגלל שהוסר ילד מהרשימה האינדקס הבא יעבור למקום של הנוכחי וצריך "לחזור אחורה"
                  }
              }
              if (children.Count() != 0)
                sortChidren(professionKind, children);//פונקציה למניעת התנגשות שני מפגשים לאותו ילד באותה השעה
              thisDay = DateTime.Now;
              //סידור המערכת לעובדת נוכחית לשבוע הקרוב
              //ע"י מעבר על כל ימי עבודתה ושיבוץ השעות בהתאם לזמני המוסד או לדרישות העובדת
              //כרגע אנחנו לא מתייחסים לדרישות עובדת כלומר כל יום מאיזה שעה עד איזה שעה אלא 
              //ממלאים לה ימים שלמים עד שנגמרות השעות כלומר היום הקצר יצא ביום האחרון בשבוע
              for (int i = 1; i <= 7; i++)
              {
                numHoursScheduledToday = 0;
                if (daysWorkProfessional.Contains(thisDay.DayOfWeek.ToString()) == true && db.Holidays.FirstOrDefault(h => h.Date == (thisDay.Date)) == null)
                {
                  dateSchedule = new DateTime(thisDay.Year, thisDay.Month, thisDay.Day, 9, 0, 0);
                  foreach (var child in children)
                  {
                    kinderGarden = db.KinderGardens.FirstOrDefault(k => k.Id == db.ChildKinderGardens.
                    FirstOrDefault(ch => ch.ChildID == child.Id).KindrGardenID);
                    dateEnd = dateSchedule.AddHours(0.75);
                    if (db.Calanders.FirstOrDefault(c => c.ChildId == child.Id
                && c.DateStart >= dateSchedule && c.DateStart < dateEnd || c.DateEnd > dateSchedule && c.DateEnd <= dateEnd) == null)
                      //הילד הזה לא שובץ כבר באותם השעות
                      if (child.NumTretments >= 1 && numHoursScheduledToday + 0.75 <= maxDailyNumHours)//להעביר את התנאי כתור תנאי הלולאה?
                      {
                        var treatment = new Calander()
                        {
                          DateStart = dateSchedule,
                          DateEnd = dateEnd,//האם השעות מתווספות?
                          ChildId = child.Id,
                          KinderGardenId = db.ChildKinderGardens.Where(ch => ch.BeginYear.Value == date)
                             .First(ch => ch.ChildID == child.Id).KindrGardenID,
                          ProfessionalId = professional.Id,
                          KindId = professionKind,//?
                          NameMeeting = child.FirstName + " " + child.LastName,
                        };
                        db.Calanders.Add(treatment);
                        child.NumTretments--;
                        dateSchedule = dateEnd.AddHours(0.25);//הפסקה של רבע שעה בין טיפול לטיפול
                        if (dateSchedule.Hour == 12)
                          if (daysMeetingsProfessional.Contains(thisDay.DayOfWeek.ToString()))//אם קיימת ישיבת צוות לעובדת באותו יום
                          {
                            if (numWindows == 0)//אין לה שעור חלון השבוע
                            {
                              dateSchedule = dateSchedule.AddHours(2);
                              numWindows++;
                            }
                            else
                              break;
                          }//נגמר השיבוץ להיום}
                          else
                            break;
                        numHoursScheduledToday += 0.75 + 0.25;
                      }
                  }
                }
                thisDay = thisDay.AddDays(1);
              }
            }
          }
        }
        db.SaveChanges();//script האם צריך על כל הכנסה או מספיק בסוף ה
        Console.WriteLine("finished");
      }
    }

    private DateTime calcNextDay(string dayName)
    {
      DateTime thisday = DateTime.Now;
      for (int i = 0; i < 7; i++)
      {
        if (thisday.DayOfWeek.ToString() == dayName)
          return thisday;
        thisday = thisday.AddDays(1);
      }
      return DateTime.Now;
    }
    private int getNumGroup(DateTime date)
    {
      if (date.Day >= 1 && date.Day <= 7)
        return 1;
      else if (date.Day >= 8 && date.Day <= 15)
        return 2;
      return 0;
    }
    public void TeamMeetings()
    {
      DateTime date;
      try
      {
        using (TafToTafEntities db = new TafToTafEntities())
        {
          int hour = 12;
          foreach (var kinderGarden in db.KinderGardens.OrderBy(knd => knd.MeetingDay))
          {
            date = calcNextDay(kinderGarden.MeetingDay);
            Calander meeting = new Calander()
            {
              DateStart = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0),
              DateEnd = new DateTime(date.Year, date.Month, date.Day, ++hour, 0, 0),
              KinderGardenId = kinderGarden.Id,
              KindId = 4,
              NameMeeting = "ישיבת צוות לגן " + kinderGarden.Name,
              ChildId = null,
              ProfessionalId = null
            };
            if (hour == 14)//איתחול שעת התחלה של הישיבה הבאה
              hour = 12;
            db.Calanders.Add(meeting);
          }
          db.SaveChanges();
        }
      }
      catch (Exception Ex)
      {
        throw new Exception(Ex.Message);
      }

    }
    public void ParentsMeetings()
    {
      DateTime meetingDate;
      DateTime treat2DateBegin;
      try
      {
        using (TafToTafEntities db = new TafToTafEntities())
        {

          foreach (var kinderGarden in db.KinderGardens.OrderBy(knd => knd.MeetingDay))
          {
            meetingDate = calcNextDay(kinderGarden.MeetingDay);
            if (getNumGroup(meetingDate) != 0)
              if (int.Parse(kinderGarden.Code) == getNumGroup(meetingDate))
              {
                var meeting = new Calander()
                {
                  DateStart = new DateTime(meetingDate.Year, meetingDate.Month, meetingDate.Day, 10, 0, 0),
                  DateEnd = new DateTime(meetingDate.Year, meetingDate.Month, meetingDate.Day, 12, 0, 0),
                  KinderGardenId = kinderGarden.Id,
                  KindId = 5,
                  NameMeeting = "ישיבת הורים לגן " + kinderGarden.Name
                };
                db.Calanders.Add(meeting);
                var treat1 = db.Calanders.FirstOrDefault(c => c.DateStart == meeting.DateStart);
                treat2DateBegin = meeting.DateStart.Value.AddHours(1);
                var treat2 = db.Calanders.FirstOrDefault(c => c.DateStart == treat2DateBegin);
                if (treat1 != null && treat1.KinderGardenId == kinderGarden.Id)
                  db.Calanders.Remove(treat1);
                if (treat2 != null && treat2.KinderGardenId == kinderGarden.Id)
                  db.Calanders.Remove(treat2);

              }
          }
          db.SaveChanges();
        }
      }
      catch (Exception Ex)
      {
        throw new Exception(Ex.Message);
      }

    }

  }
}

