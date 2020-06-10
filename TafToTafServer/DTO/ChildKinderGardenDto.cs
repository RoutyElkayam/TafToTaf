using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChildKinderGardenDto
    {
        public int Id { get; set; }
        public int ChildID { get; set; }
        public int KindrGardenID { get; set; }
        public DateTime BeginYear { get; set; }
        public DateTime EndYear { get; set; }
        public int EntitlementID { get; set; }

        //public virtual Child Child { get; set; }
        //public virtual Entitlement Entitlement { get; set; }
        //public virtual KinderGarden KinderGarden { get; set; }
    }
}
