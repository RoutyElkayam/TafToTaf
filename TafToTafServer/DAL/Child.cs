//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Child
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Child()
        {
            this.Calanders = new HashSet<Calander>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Tz { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BornDate { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<double> NumHoursConfirm { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calander> Calanders { get; set; }
        public virtual User User { get; set; }
    }
}
