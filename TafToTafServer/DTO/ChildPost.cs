using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
  public class ChildPost
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Tz { get; set; }
    public string LastName { get; set; }
    public DateTime BornDate { get; set; }
    public double NumHoursConfirm { get; set; }
    public string ParentName { get; set; }
    public string ParentEmail { get; set; }
  }
}
