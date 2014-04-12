using Neusoft.CCS.Services.Implementation;
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
            var tmpService = DI.SpringHelper.GetObject<IComplaintInfoService>("ComplaintInfoService").GetNotArchivedComplaintInfo(0, 99);
            return View();
        }

        /// <summary>
        /// 投诉处理总览
        /// </summary>
        /// <returns></returns>
        public ActionResult ComplaintOverview()
        {
            var list = DI.SpringHelper.GetObject<IComplaintInfoService>("ComplaintInfoService").GetNotArchivedComplaintInfo(0, 20);
            return View(list);
        }

    }
}
