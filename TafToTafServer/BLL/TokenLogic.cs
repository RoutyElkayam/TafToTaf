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
      return string.Format("yJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJ" +
        "pc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE1OTI2ODI3MDksImV4c" +
        "CI6MTYyNDIxODcwOSwiYXVkIjoiIiwic3ViIjoiIn0.tuozOiPLZdYVwl2OSGm" +
        "AzjP0p0cY6u4j36uUQNAtrYuGqXiIapZEhcaS6hqPMtFvv15EcsiAcOmDuuK58" +
        "ucq2g {0}   *23456578fgh*&", id);
    }
    public static int DecodeToken(string token)
    {
      return int.Parse(token.Substring(231, 4));
    }
  }
}
