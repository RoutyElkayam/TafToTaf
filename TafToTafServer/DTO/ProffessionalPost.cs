using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class ProffessionalPost
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProfessionKind { get; set; }
    public int NumHourWork { get; set; }
    public int NumDaysWork { get; set; }
    public bool Sunday { get; set; }
    public bool Monday { get; set; }
    public bool Thuesday { get; set; }
    public bool Wednesday { get; set; }
    public bool Tursday { get; set; }
    public string ProffesionalEmail { get; set; }
  }
}
