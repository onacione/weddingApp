using Dugun.Controllers;
using Dugun.Models;
using Dugun.Models.Managers;
using Dugun.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Dugun.Controllers
{
    public class MainController : Controller 
    {
        DugunEntities _context = new DugunEntities();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUser")]
        public UserDto GetUser(int UserID)
        {
           return UserManager.Instance.GetUser(UserID, _context);
        }

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetUser")]
        public UserDto SetUser(UserDto dto)
        {
            return UserManager.Instance.SetUser(dto, _context);
        }

    }
}