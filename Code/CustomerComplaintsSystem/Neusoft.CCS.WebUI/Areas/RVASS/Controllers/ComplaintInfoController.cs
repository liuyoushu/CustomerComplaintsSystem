using Neusoft.CCS.Services.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neusoft.CCS.WebUI.Areas.RVASS.Controllers
{
    public class ComplaintInfoController : Controller
    {
        //
        // GET: /RVASS/ComplaintInfo/

        public ActionResult Index()
        {
            var tmp = ObjectFactory.GetInstance<IComplaintInfoService>().GetNotArchivedComplaintInfo();
            return View();
        }

    }
}
