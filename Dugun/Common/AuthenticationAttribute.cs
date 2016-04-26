using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dugun.Common
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AuthenticationAttribute : Attribute
    {
        public AuthenticationAttribute()
        {

        }

        public AuthenticationType Auth { get; set; }
        
        public override string ToString()
        {
            return Auth.ToString();
        }

        //public static bool IsAuthenticated(object sender, string name)
        //{
        //    List<AuthenticationType> needAttributes = null;
        //    if (sender is WinService)
        //    {
        //        needAttributes = sender.GetType().GetInterfaces()[0].GetMethod(name).GetCustomAttributes(true).OfType<AuthenticationAttribute>().Select(x => (x as AuthenticationAttribute).Auth).ToList();
        //    }
        //    else
        //    {
        //        needAttributes = sender.GetType().GetMethod(name).GetCustomAttributes(true).OfType<AuthenticationAttribute>().Select(x => (x as AuthenticationAttribute).Auth).ToList();
        //    }

        //    if (needAttributes.Count > 0)
        //    {
        //        if (needAttributes.Contains(AuthenticationType.Everyone))
        //        {
        //            return true;
        //        }
        //        else if (SessionControl.UserStatus == null || !needAttributes.Contains((AuthenticationType)SessionControl.UserStatus.UserType))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public static bool IsAuthenticated()
        {
             if (SessionControl.UserStatus == null)
                 return false;
             else
                return true;
        }


        public static bool CheckAuthentication(object sender, string name)
        {
            return IsAuthenticated();
        }
    }

    public enum AuthenticationType
    {
        Everyone = 1,
        User = 2,
        Admin = 3
    }
}