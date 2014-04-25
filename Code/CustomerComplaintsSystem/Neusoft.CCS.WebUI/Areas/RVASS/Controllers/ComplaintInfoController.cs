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
            return View();
        }

        /// <summary>
        /// 投诉处理总览
        /// </summary>
        /// <returns></returns>
        public ActionResult ComplaintOverview()
        {
            var response = DI.SpringHelper.GetObject<IComplaintInfoService>("ComplaintInfoService").GetNotArchivedComplaintInfo();
            if (response.IsSuccess)
            {
                return View(response.NotArchivedComplaint);
            }
            else
            {
                return View(response.ErrorMessage);
            }
        }

    }
}
