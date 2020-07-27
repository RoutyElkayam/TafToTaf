using BLL.Converters;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
 public class KinderGardenLogic
  {
    public static List<KinderGardenDto> SelectKinderGardens()
    {
      List<KinderGardenDto> listKinderGardens = new List<KinderGardenDto>();
      using (DAL.TafToTafEntities db = new DAL.TafToTafEntities())
      {
        var kinderGardens = db.KinderGardens.ToList();
        foreach (var kinderGarden in kinderGardens)
        {
          listKinderGardens.Add(KinderGardenC.ToKinderGardenDto(kinderGarden));
        }
      }
      return listKinderGardens;
    }
    
  }
}
