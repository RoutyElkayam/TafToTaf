using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class ChildDto
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Tz { get; set; }
    public string LastName { get; set; }
    public DateTime BornDate { get; set; }
    public int ParentID { get; set; }
    public double NumHoursConfirm { get; set; }
  }

}
