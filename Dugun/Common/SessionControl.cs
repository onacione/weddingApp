using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;
using Dugun.Models.DataTransferObjects;

namespace Dugun.Common
{
    public class SessionControl
    {
        public static UserDto UserStatus
        {
            get
            {
                return HttpContext.Current.Session["UserStatus"] as UserDto;
            }
            set { HttpContext.Current.Session["UserStatus"] = value; }
        }
    }
}