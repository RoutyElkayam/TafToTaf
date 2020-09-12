using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Converters;
using DAL;

namespace BLL
{
  public class ChildLogic
  {
    public static ChildDto SelectChild(int id)
    {
      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
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
      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
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
      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
      {
        var children = db.Children.OrderBy(c=>c.LastName).ToList();
        foreach (var child in children)
        {
          childrenList.Add(ChildC.ToChildDTO(child));
        }
      }
      return childrenList;
    }
    public static void InsertChild(ChildDto child, string kGardenName)
    {

      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
      {
        int kGardenID = db.KinderGardens.First(kg => kg.Name == kGardenName).Id;
        db.Children.Add(ChildC.ToChildDAL(child));
        db.ChildKinderGardens.Add(new ChildKinderGarden()
        {
          ChildID = child.Id,
          KindrGardenID = kGardenID,
          BeginYear= PublicLogic.CalcBeaginYear(),
          EndYear=   PublicLogic.CalcEndYear(),
        });

        db.SaveChanges();
      }
    }
    public static void DeleteChild(int id)
    {
      try
      {
        using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
        {
          var child = db.Children.FirstOrDefault(ch => ch.Id == id);
          if (child != null)
          {
            db.Children.Remove(child);
          }
          foreach (var childInKGarden in db.ChildKinderGardens)
          {
            if (childInKGarden.ChildID == id)
              db.ChildKinderGardens.Remove(childInKGarden);
          }
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
      using (DAL.TafToTafEntities1 db = new DAL.TafToTafEntities1())
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


