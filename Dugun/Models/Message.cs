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
    
    public partial class Message
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public bool IsRead { get; set; }
        public int UserIDSender { get; set; }
        public int UserIDReceiver { get; set; }
        public Nullable<int> MessageType { get; set; }
        public Nullable<System.DateTime> DtInsert { get; set; }
        public Nullable<System.DateTime> DtUpdate { get; set; }
        public Nullable<int> RowStatus { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
