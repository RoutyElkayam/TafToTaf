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
      using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
      {
        var child = db.Children.FirstOrDefault(ch => ch.Id == id);
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
      using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
      {
        var children = db.Children.ToList();
        foreach (var child in children)
        {
          childrenList.Add(ChildC.ToChildDTO(child));
        }
      }
      return childrenList;
    }
    public static void InsertChild(ChildDto child, string kGardenName)
    {
      using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
      {
        int kGardenID = db.KinderGardens.First(kg => kg.Name == kGardenName).Id;
        db.Children.Add(ChildC.ToChildDAL(child));
        db.ChildKinderGardens.Add(new ChildKinderGarden()
        {
          ChildID = child.Id,
          KindrGardenID = kGardenID,
          BeginYear = calcBeaginYear(),
          EndYear = calcEndYear(),
        });

        db.SaveChanges();
      }
    }
    public static void DeleteChild(int id)
    {
      try
      {
        using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
        {
          var Child = db.Children.FirstOrDefault(ch => ch.Id == id);
          if (Child != null)
          {
            db.Children.Remove(Child);
            db.SaveChanges();
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static void EditChild(int id, ChildDto child)
    {
      using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
      {
        var editChild = db.Children.FirstOrDefault(ch => ch.Id == id);
        if (editChild != null)
        {
          editChild.FirstName = child.FirstName;
          editChild.LastName = child.LastName;
          editChild.Tz = child.Tz;
          editChild.BornDate = child.BornDate;
          editChild.NumHoursConfirm = child.NumHoursConfirm;

        }
        db.SaveChanges();
      }
    }
    //help functions
    private static DateTime calcBeaginYear()
    {
      if (DateTime.Now.Month > 09)
        return new DateTime(DateTime.Now.Year, 09, 01);
      return new DateTime(DateTime.Now.Year - 1, 09, 01);

    }
    private static DateTime calcEndYear()
    {
      if (DateTime.Now.Month > 09)
        return new DateTime(DateTime.Now.Year + 1, 07, 01);
      return new DateTime(DateTime.Now.Year, 07, 01);

    }
  }
}
