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
    
    public partial class Service
    {
        public Service()
        {
            this.Guest = new HashSet<Guest>();
        }
    
        public int ServiceID { get; set; }
        public string CaptainName { get; set; }
        public Nullable<decimal> CaptainTelNo { get; set; }
        public Nullable<int> RouteID { get; set; }
        public Nullable<int> DugunID { get; set; }
        public Nullable<int> PersonCount { get; set; }
        public Nullable<System.DateTime> DtInsert { get; set; }
        public Nullable<System.DateTime> DtUpdate { get; set; }
        public Nullable<int> RowStatus { get; set; }
    
        public virtual Dugun Dugun { get; set; }
        public virtual ICollection<Guest> Guest { get; set; }
        public virtual Route Route { get; set; }
    }
}
