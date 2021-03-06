using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using BLL.Converters;
using DAL;

namespace BLL
{

  public class ChildLogic
  {
    static int year = PublicLogic.CalcBeaginYear().Year;
    public static ChildDto SelectChild(int id)
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var child = db.Children.FirstOrDefault(ch => ch.Id == id);
        if (child == null)
        {
          return null;
        }
        return Converters.ChildC.ToChildDTO(child);
      }
    }
    public static ChildDto SelectChildByParentId(int parentId)
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var child = db.Children.FirstOrDefault(ch => ch.ParentID == parentId);
        if (child == null)
        {
          return null;
        }
        return Converters.ChildC.ToChildDTO(child);
      }
    }
    public static List<ChildDto> SelectChildren()
    {
      List<ChildDto> childrenList = new List<ChildDto>();
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var children = db.Children.OrderBy(c=>c.LastName).ToList();
        foreach (var child in children)
        {
          childrenList.Add(ChildC.ToChildDTO(child));
        }
      }
      return childrenList;
    }
    public static List<ChildDto> SelectWorkerChildren(int workerID)
    {
      List<int> childrenIDs = new List<int>();
      List<ChildDto> childrenList = new List<ChildDto>();
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var calendersWorker = db.Calanders.Where(c => c.ProfessionalId==workerID&&c.DateStart!=null&&c.DateStart.Value.Year==year).ToList();
        foreach (var calendar in calendersWorker)
        {
          if(childrenIDs.Contains(calendar.ChildId.GetValueOrDefault())==false)
          {
            childrenIDs.Add(calendar.ChildId.GetValueOrDefault());
            childrenList.Add(ChildC.ToChildDTO(db.Children.First(ch => ch.Id == calendar.ChildId)));
          }
        }
      }
      return childrenList;
    }

    public static void InsertChild(DTO.ChildPost child, string kGardenName)
    {

      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        int kGardenID = db.KinderGardens.First(kg => kg.Name == kGardenName).Id;
        User user = new User()
        {
          LastName = child.LastName,
          FirstName = child.ParentName,
          KindUser = 3,
          UserName = "TLT" + "3",
          Email = child.ParentEmail,
          Password = child.Tz,
        };
        db.Users.Add(user);
        db.SaveChanges();
        ChildDto childDto = new ChildDto()
        {
          FirstName = child.FirstName,
          LastName = child.LastName,
          BornDate = child.BornDate,
          NumHoursConfirm = child.NumHoursConfirm,
          Tz = child.Tz,
          ParentID = db.Users.First(u => u.Password == child.Tz).Id
        };
        db.Children.Add(ChildC.ToChildDAL(childDto));
        db.ChildKinderGardens.Add(new ChildKinderGarden()
        {
          ChildID = child.Id,
          KindrGardenID = kGardenID,
          BeginYear= PublicLogic.CalcBeaginYear(),
          EndYear=   PublicLogic.CalcEndYear(),
        });
       db.SaveChanges();
        PublicLogic.SendEmail("TLT3", child.Tz, child.ParentEmail);
      }
    }
    public static void DeleteChild(int id)
    {
      try
      {
        using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
        {
          var child = db.Children.FirstOrDefault(ch => ch.Id == id);
          if (child != null)
          {
            db.Children.Remove(child);
          }
          var childInKGarden = db.ChildKinderGardens.First(ch => ch.ChildID == id);
          db.ChildKinderGardens.Remove(childInKGarden);
          var parent = db.Users.FirstOrDefault(u => u.Password == child.Tz);
          if (parent != null)
            db.Users.Remove(parent);
          db.SaveChanges();
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
    public static void EditChild(int id, ChildDto child)
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var editChild = db.Children.FirstOrDefault(ch => ch.Id == id);
        if (editChild != null)
        {
          editChild.FirstName = child.FirstName;
          editChild.LastName = child.LastName;
          editChild.Tz = child.Tz;
          editChild.BornDate = child.BornDate;
          editChild.NumHoursConfirm = child.NumHoursConfirm;
          editChild.ParentID = child.ParentID;

        }
        db.SaveChanges();
      }
    }
  }
}


