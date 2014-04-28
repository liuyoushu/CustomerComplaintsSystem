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

        /// <summary>
        /// 投诉案件详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ObserveComplaintInfoDetail(int id)
        {
            var response = DI.SpringHelper.GetObject<IComplaintInfoService>("ComplaintInfoService").Detailed(id);
            if (response.IsSuccess)
            {
                return View(response.DetailedComplaintInfo);
            }
            else
            {
                return View(response.ErrorMessage);
            }
        }

    }
}
