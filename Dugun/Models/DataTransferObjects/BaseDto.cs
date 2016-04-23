using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dugun.Models
{
    public class BaseDto
    {
        #region Common Properties

        private Nullable<DateTime> dtInsert;
        public Nullable<DateTime> DtInsert
        {
            get
            {
                if (dtInsert == null)
                {
                    return DateTime.Now;
                }
                return dtInsert;
            }
            set
            {
                dtInsert = value;
            }
        }
        
        public Nullable<DateTime> DtUpdate { get; set; }
        public Nullable<int> RowStatus { get; set; }

        #endregion

      
    }
}