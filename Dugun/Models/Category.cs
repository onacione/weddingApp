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
    
    public partial class Category
    {
        public Category()
        {
            this.Guest = new HashSet<Guest>();
        }
    
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<System.DateTime> DtInsert { get; set; }
        public Nullable<System.DateTime> DtUpdate { get; set; }
        public Nullable<int> RowStatus { get; set; }
    
        public virtual ICollection<Guest> Guest { get; set; }
    }
}
