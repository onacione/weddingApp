using Dugun.Controllers;
using Dugun.Models;
using Dugun.Common;
using Dugun.Models.DataService;
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

       [OperationContract]
       [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetUser")]
        public GuestDto SetGuest(GuestDto dto)
       {
           return Dispatcher.Invoke(() => GuestManager.Instance.SetGuest(dto, null), GuestManager.Instance) as GuestDto;
       }

    }
}