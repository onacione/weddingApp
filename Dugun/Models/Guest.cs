//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dugun.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guest
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<decimal> TelNo { get; set; }
        public Nullable<bool> State { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<bool> Alcoholic { get; set; }
        public Nullable<int> TableID { get; set; }
        public Nullable<int> DugunID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<System.DateTime> DtInsert { get; set; }
        public Nullable<System.DateTime> DtUpdate { get; set; }
        public Nullable<int> RowStatus { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Dugun Dugun { get; set; }
        public virtual Service Service { get; set; }
        public virtual Table Table { get; set; }
    }
}
