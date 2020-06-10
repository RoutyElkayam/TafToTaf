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
        public DateTime Date { get; set; }
        public int KinderGardenId { get; set; }
        public int ProfessionalId { get; set; }
        public int KindId { get; set; }
    }
}
