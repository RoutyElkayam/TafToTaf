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
      using(DAL.TafToTafEntities db= new DAL.TafToTafEntities())
      {
        var child = db.Children.FirstOrDefault(ch =>ch.Id==id);
        if(child==null)
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
    public static void InsertChild(ChildDto child)
    {
      using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
      {
        db.Children.Add(ChildC.ToChildDAL(child));
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
      catch(Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
    //חסר Update ,GetListChildren
    //public static void EditChild(int id,ChildDto child)
    //{
    //  using (DAL.masterEntities db = new DAL.masterEntities())
    //  {
    //    if (db.Children.FirstOrDefault(ch => ch.Id == id) != null)
    //    {
    //      db.Children.FirstOrDefault(ch => ch.Id == id) = ChildC.ToChildDAL(child);
    //    }
    //  }
    //}
  }
}
