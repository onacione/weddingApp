using Dugun.Common;
using Dugun.Models.DataService;
using Dugun.Models.DataTransferObjects;
using Dugun.Models.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Security;


namespace Dugun
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WinService : IWinService
    {

        #region Singleton Instance

        private static WinService instance;

        private WinService() { }

        public static WinService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WinService();
                }
                return instance;
            }
        }

        #endregion

        #region User
        public UserDto SetUser(UserDto dto)
        {
            return Dispatcher.Invoke(() => UserManager.Instance.SetUser(dto, null), UserManager.Instance) as UserDto;
        }

        #endregion

        #region Guest

        public GuestDto SetGuest(GuestDto dto)
        {
            return Dispatcher.Invoke(() => GuestManager.Instance.SetGuest(dto, null), GuestManager.Instance) as GuestDto;
        }
        #endregion

        #region Table
        #endregion

        #region Category

        public CategoryDto SetCategory(CategoryDto dto)
        {
            return Dispatcher.Invoke(() => CategoryManager.Instance.SetCategory(dto, null), CategoryManager.Instance) as CategoryDto;
        }

        #endregion

        #region Note/Message

 

        #endregion

        #region Service

        #endregion

        #region Dugun

        #endregion

        #region DugunSalonu

        #endregion

        #region Route

        #endregion

        #region UserType

        #endregion


       
    }
} 



