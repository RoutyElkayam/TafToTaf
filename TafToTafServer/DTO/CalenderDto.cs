using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class CalenderDto
  {
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    //public int KinderGardenId { get; set; }
    //public int ProfessionalId { get; set; }
    //public int KindId { get; set; }
    //public int ChildID { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
  }
}
