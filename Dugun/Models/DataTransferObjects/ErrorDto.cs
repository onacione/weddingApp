using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dugun.Models.DataTransferObjects
{
    public class ErrorDto
    {
        #region Properties

        public string ErrorMessage { get; set; }
        
        public bool IsError { get; set; }

        #endregion
    }
}