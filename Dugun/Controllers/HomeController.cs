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
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Guests()
        {
            
            return View();
        }

        public ActionResult Notes()
        {
            return View();
        }

        public ActionResult TableSettings()
        {
            return View();
        }

        public ActionResult Categories()
        {
            CategoryDto dto = new CategoryDto();
            dto.CategoryName = "asdfasf";
            WinService.Instance.SetCategory(dto);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}