using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neusoft.CCS.Services.Implementation;
using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.ViewModels;
using Neusoft.CCS.Services.Mappings;

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

        /// <summary>
        /// 投诉回访单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ReturnVisiting(int id)
        {
            var response = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoService>("ComplaintReturnVisitInfoService").LoadingReturnVisitForm(id);
            if (response.IsSuccess)
            {
                response.ReturnVisitForm.BeginTime = DateTime.Now;//记录开始回访时间
                return View(response.ReturnVisitForm);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult ReturnVisiting(ReturnVisitFormViewModel model)
        {
            model.ReturnVisitDate = DateTime.Now;//记录时间
            model.EndTime = DateTime.Now;//记录结束时间
            if (DI.SpringHelper.GetObject<IComplaintReturnVisitInfoService>("ComplaintReturnVisitInfoService").SubmitReturnVisitForm(model))
            {

            }
            return View();
        }

    }
}
