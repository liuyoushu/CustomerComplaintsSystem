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

        /// <summary>
        /// 待回访列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ComplaintReturnVisitBox()
        {
            var response = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoService>("ComplaintReturnVisitInfoService").LoadingReturnVisitBox();
            if (!response.IsSuccess)
            {
                Response.Write("<script>alert('" + response.ErrorMessage + "')</script>");
            }
            return View(response.RetrunVisitBox);
        }

        /// <summary>
        /// 读取投诉反馈回访单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]//PRG之G
        public ActionResult ReturnVisiting(int id)
        {
            var response = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoService>("ComplaintReturnVisitInfoService").LoadingReturnVisitForm(id);
            if (!response.IsSuccess)
            {
                Response.Write("<script>alert('" + response.ErrorMessage + "')</script>");
            }
            return View(response.ReturnVisitForm);
        }

        /// <summary>
        /// 提交投诉反馈回访单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]//PRG之P 
        public ActionResult ReturnVisiting(ReturnVisitFormViewModel model)
        {
            if (!DI.SpringHelper.GetObject<IComplaintReturnVisitInfoService>("ComplaintReturnVisitInfoService").SubmitReturnVisitForm(model))
            {
                Response.Write("<script>alert('提交投诉反馈回访单失败！')</script>");
            }
            return RedirectToAction("ComplaintReturnVisitBox", "ComplaintReturnVisitInfo");
        }

    }
}
