using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neusoft.CCS.Services.Implementation;
using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.ViewModels;
using Neusoft.CCS.Services.Mappings;
using Neusoft.CCS.Services.Messages;

namespace Neusoft.CCS.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Login/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginedStaffViewModel loginedStaff)
        {
            var logined = DI.SpringHelper.GetObject<IStaffService>("StaffService").Login(loginedStaff);
            Session["LoginedStaff"] = logined;
            return RedirectToAction("Welcome");
        }

        public ActionResult Welcome()
        {
            return View();
        }

    }
}
