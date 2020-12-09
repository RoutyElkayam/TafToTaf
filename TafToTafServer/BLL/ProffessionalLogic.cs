using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL.Converters;

namespace BLL
{
  public class ProffessionalLogic
  {
    public static ProfessionalDTO SelectProfessional(int id)
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var professional = db.Professionals.FirstOrDefault(p => p.Id == id);
        if (professional == null)
        {
          return null;
        }
        return Converters.ProfessionalC.ToProfessionalDto(professional);
      }
    }
    public static ProfessionalDTO SelectProfessionalByUserID(int id)
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var professional = db.Professionals.FirstOrDefault(p => p.userID == id);
        if (professional == null)
        {
          return null;
        }
        return Converters.ProfessionalC.ToProfessionalDto(professional);
      }
    }
    public static List<ProfessionalDTO> SelectProffesionals()
    {
      List<ProfessionalDTO> ProffesionalsList = new List<ProfessionalDTO>();
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var proffesionals = db.Professionals.OrderBy(p => p.ProfessionKind).ToList();
        foreach (var proffesional in proffesionals)
        {
          ProffesionalsList.Add(ProfessionalC.ToProfessionalDto(proffesional));
        }
      }
      return ProffesionalsList;
    }
    public static void InsertProffesional(DTO.ProffessionalPost proffessional)
    {

      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        db.Users.Add
          (
             new DAL.User()
             {
               KindUser = 2,
               FirstName = proffessional.Name,
               UserName = "TLT2",
               Password = proffessional.Id.ToString(),
               Email = proffessional.ProffesionalEmail,
               LastName = ""
             }
          );
        db.SaveChanges();
        ProfessionalDTO professionalDto = new ProfessionalDTO()
        {
          Monday = proffessional.Monday,
          Name = proffessional.Name,
          NumHourWork = proffessional.NumHourWork,
          ProfessionKind = proffessional.ProfessionKind,
          Sunday = proffessional.Sunday,
          Thuesday = proffessional.Thuesday,
          Tursday = proffessional.Tursday,
          Wednesday = proffessional.Wednesday,
          UserID = db.Users.FirstOrDefault(u => u.Password == proffessional.Id.ToString()).Id
        };
        db.Professionals.Add(ProfessionalC.ToProfessional(professionalDto));
        //send Email Please
        db.SaveChanges();
      }
      PublicLogic.SendEmail("TLT2", proffessional.Id.ToString(), proffessional.ProffesionalEmail);
    }
    public static void DeleteProffesional(int id)
    {
      try
      {
        using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
        {
          var proffesional = db.Professionals.FirstOrDefault(p => p.Id == id);
          if (proffesional != null)
          {
            db.Professionals.Remove(proffesional);
          }
          var userProffesional = db.Users.FirstOrDefault(uP => uP.Password == proffesional.Id.ToString());
          if (userProffesional != null)
            db.Users.Remove(userProffesional);
          db.SaveChanges();
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
    public static void EditProffesional(int id, DTO.ProfessionalDTO professional)
    {
      using (DAL.TafToTafEntities2 db = new DAL.TafToTafEntities2())
      {
        var editProffesional = db.Professionals.FirstOrDefault(p => p.Id == id);
        if (editProffesional != null)
        {
          editProffesional.Name = professional.Name;
          editProffesional.NumHourWork = professional.NumHourWork;
          editProffesional.Sunday = professional.Sunday;
          editProffesional.Monday = professional.Monday;
          editProffesional.Thuesday = professional.Thuesday;
          editProffesional.Wednesday = professional.Wednesday;
          editProffesional.Tursday = professional.Tursday;
        }
        db.SaveChanges();
      }
    }
  }
}
