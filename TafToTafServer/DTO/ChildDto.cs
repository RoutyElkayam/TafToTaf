using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChildDto :IComparable<ChildDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Tz { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public double NumHoursConfirm { get; set; }
        public int ParentID { get; set; }

    public int CompareTo(ChildDto other)
    {
      if (other.LastName[0] == this.LastName[0])
        return 0;
      if (other.LastName[0] > this.LastName[0])
        return 1;
      return -1;
    }
  }

}
