using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class TokenLogic
  {
    public static string EncodeToken(int id)
    {
      return string.Format("% 45678#@dfgh2s23bht2& {0} *23456578fgh*&",id);
    }
    public static int DecodeToken(string token)
    {
      //decode is missing
      return 0;
    } 
  }
}
