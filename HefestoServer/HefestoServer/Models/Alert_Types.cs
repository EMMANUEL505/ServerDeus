//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HefestoServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alert_Types
    {
        public Alert_Types()
        {
            this.Alerts = new HashSet<Alerts>();
        }
    
        public int Alert_Typeid { get; set; }
        public string Alert_Description { get; set; }
        public Nullable<int> Alert_Priority { get; set; }
        public string Alert_Email { get; set; }
    
        public virtual ICollection<Alerts> Alerts { get; set; }
    }
}
