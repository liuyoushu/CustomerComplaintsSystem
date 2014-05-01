using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neusoft.CCS.Services.Implementation;
using Neusoft.CCS.Services.Interfaces;

namespace Neusoft.CCS.WebUI.Areas.RVASS.Controllers
{
    public class ComplaintReturnVisitInfoController : Controller
    {
        //
        // GET: /RVASS/ComplaintReturnVisitInfo/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 待回访列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ComplaintReturnVisitBox()
        {
            var response = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoService>("ComplaintReturnVisitInfoService").LoadingReturnVisitBox();
            if (response.IsSuccess)
            {
                return View(response.RetrunVisitBox);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ReturnVisiting()
        {

        }

    }
}
