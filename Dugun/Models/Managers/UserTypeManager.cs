using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;
using Dugun.Common;
using Dugun.Models.DataTransferObjects;
using System.Data.Entity.Validation;
namespace Dugun.Models.Managers
{
    public class UserTypeManager
    {
         #region Singleton Instance

        private static UserTypeManager instance;

        private UserTypeManager() { }

        public static UserTypeManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserTypeManager();
                }
                return instance;
            }
        }

        #endregion

        
    }
}