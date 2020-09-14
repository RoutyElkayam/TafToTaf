using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    public static void SendEmail(string userName, string password, string email)
    {
      try
      {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        mail.From = new MailAddress("taftotafusers@gmail.com");
        mail.To.Add(email);
        mail.Subject = "נרשמת בהצלחה למערכת טף לטף";
        mail.Body = "שם המשתמש שלך הוא" + ":" + userName + " הסיסמא שלך היא:" + password + " המשך יום מגניב!! צוות טף לטף ";
         ;

        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("taftotafusers@gmail.com", "taftotaf123");
        SmtpServer.EnableSsl = true;

        SmtpServer.Send(mail);
       
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
  }
}

