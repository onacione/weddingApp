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
    
    public partial class UserType
    {
        public UserType()
        {
            this.User = new HashSet<User>();
        }
    
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public Nullable<System.DateTime> DtInsert { get; set; }
        public Nullable<System.DateTime> DtUpdate { get; set; }
        public Nullable<int> RowStatus { get; set; }
    
        public virtual ICollection<User> User { get; set; }
    }
}
