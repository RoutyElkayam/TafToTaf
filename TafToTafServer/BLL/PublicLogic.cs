using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class PublicLogic
  {
    //help functions--Dates
    public static DateTime CalcBeaginYear()
    {
      if (DateTime.Now.Month >= 09)
        return new DateTime(DateTime.Now.Year, 09, 01);
      return new DateTime(DateTime.Now.Year - 1, 09, 01);

    }
    public static DateTime CalcEndYear()
    {
      if (DateTime.Now.Month >= 09)
        return new DateTime(DateTime.Now.Year + 1, 07, 01);
      return new DateTime(DateTime.Now.Year, 07, 01);

    }
  }
}
