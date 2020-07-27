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
    public static void InsertChild(ChildDto child, string kinderGardenName)
    {

      using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
      {
        int kGardenID = db.KinderGardens.FirstOrDefault(kg => kg.Name == kinderGardenName).Id;

        db.Children.Add(ChildC.ToChildDAL(child));
        db.ChildKinderGardens.Add(new ChildKinderGarden()
        {
          KindrGardenID = kGardenID,
          ChildID = child.Id,
          BeginYear = new DateTime(DateTime.Now.Year - 1, 09, 01),
          EndYear = new DateTime(DateTime.Now.Year, 07, 01)
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
          var child = db.Children.FirstOrDefault(ch => ch.Id == id);
          var childInKG = db.ChildKinderGardens.FirstOrDefault(ch => ch.ChildID == id);
          if (child != null)
          {
            db.Children.Remove(child);
          }
          if (childInKG != null)
          {
            db.ChildKinderGardens.Remove(childInKG);
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
  using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
  {
    var childDal = db.Children.FirstOrDefault(ch => ch.Id == child.Id);
    if (childDal != null)
    {
      childDal = ChildC.ToChildDAL(child);
      db.SaveChanges();
    }
  }
}
  }
}
