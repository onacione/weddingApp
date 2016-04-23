using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dugun.Common
{
    public class EnumObj
    {

    }

    public static class Enums
    { 
        public enum RowStatus
        {
            PASSIVE = 0,
            ACTIVE = 1
        }

        public enum FileType
        { 
            POST = 1,
            UPLOAD = 2,
            VIDEO = 3,
            PRESS = 4
        }


        public enum UserType
        {
            WSOwner = 1,
            WOWNER = 2,
            WSPERSONEL = 3,
            ADMIN = 4,
        }
    }
}