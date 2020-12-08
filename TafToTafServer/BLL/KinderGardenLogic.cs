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
    static int year = PublicLogic.CalcBeaginYear().Year;
    public static List<KinderGardenDto> SelectKinderGardens()
    {
      List<KinderGardenDto> listKinderGardens = new List<KinderGardenDto>();
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var kinderGardens = db.KinderGardens.ToList();
        foreach (var kinderGarden in kinderGardens)
        {
          listKinderGardens.Add(KinderGardenC.ToKinderGardenDto(kinderGarden));
        }
      }
      return listKinderGardens;
    }
    public static List<KinderGardenDto> SelectWorkersKinderGardens(int profossionalId)//בוחרת גנים שהעובדת עובדת בהם
    {
      List<KinderGardenDto> listKinderGardens = new List<KinderGardenDto>();
     List<int> kndId = new List<int>();
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var calendersKinderGarden = db.Calanders.Where(c => c.ProfessionalId==profossionalId&&c.DateStart!=null&&c.DateStart.Value.Year==year).ToList();
        
        foreach (var calenderkndg in calendersKinderGarden)
        {
          if (kndId.Contains(calenderkndg.KinderGardenId.Value) == false)
            kndId.Add(calenderkndg.KinderGardenId.Value);
        }
        foreach (var kndid in kndId)
        {
          listKinderGardens.Add(KinderGardenC.ToKinderGardenDto(db.KinderGardens.First(knd => knd.Id == kndid)));
        }
      }
      return listKinderGardens;
    }


  }
}
