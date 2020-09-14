using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Converters;
using DAL;
using DTO;

namespace BLL
{
  public class ChildKinderGardenLogic
  {
    public static List<ChildDto> GetChildrenInKinderGarden(string kinderGardenName)
    {
      List<ChildDto> ChildrenDTO = new List<ChildDto>();
      using (TafToTafEntities1 db = new TafToTafEntities1())
      {
        int kinderGardenId = db.KinderGardens.First(kg => kg.Name == kinderGardenName).Id;
        foreach (var childKinderGarden in db.ChildKinderGardens)
        {
          if (childKinderGarden.KindrGardenID== kinderGardenId
            && childKinderGarden.BeginYear.GetValueOrDefault()==PublicLogic.CalcBeaginYear())
          {
            Child childDAL=db.Children.First(ch => ch.Id == childKinderGarden.ChildID);
            ChildrenDTO.Add(ChildC.ToChildDTO(childDAL));
          }
        }
        return ChildrenDTO;
      }
    }

    public static string GetKinderGardenOfChild(int childID)
    {
      using (TafToTafEntities1 db = new TafToTafEntities1())
      {
        var childKG=db.ChildKinderGardens.FirstOrDefault(ch => ch.ChildID == childID);
        if (childKG == null)
          return null;
        string kGardenName = db.KinderGardens.First(ch => ch.Id == childKG.KindrGardenID).Name;
         return kGardenName;
      }
    }
  }
}
