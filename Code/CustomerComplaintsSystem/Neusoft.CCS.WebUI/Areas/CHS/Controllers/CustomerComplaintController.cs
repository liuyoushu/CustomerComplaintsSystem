using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neusoft.CCS.WebUI.Areas.CHS.Controllers
{
    public class CustomerComplaintController : Controller
    {
        //
        // GET: /CHS/CustomerComplaint/

        public ActionResult Index()
        {
            var tmpService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").GetAllBusinesses();
            if (tmpService.IsSuccess)
                return View("CreateComplaintView", tmpService.AllBusinesses);
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }
        /// <summary>
        /// 发起网络投诉
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateComplaint(CreateComplaintViewModel request)
        {
            request.Date = DateTime.Now;
            var tmpService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").CreateComplaint(request);
            // return View(tmpService.NotArchivedComplaint);
            var businessService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").GetAllBusinesses();
            if (businessService.IsSuccess)
                return View("CreateComplaintView", businessService.AllBusinesses);
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }

        public ActionResult SearchComplaintByUser()
        {
            return View("SearchComplaintByUserOverView");
        }

        /// <summary>
        /// 根据客户获取所有投诉案件
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetComplaintByUser(string name, string phone, string email)
        {
            var tmpService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").GetComplaintByUser(name, phone, email);
            if (tmpService.IsSuccess)
                return View("SearchComplaintByUserOverView", tmpService.ComplaintOverView);
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
                
        }

        /// <summary>
        /// 查看详细投诉处理结果
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult GetComplaintDetailByID(string ID)
        {
            var tmpService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").GetComplaintDetailByID(ID);
            if (tmpService.IsSuccess)
            {
                return View("ComplaintHandlingDetailView", tmpService.CaseDetail);
            }
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }

        /// <summary>
        /// 保存解决方案
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Solution"></param>
        /// <returns></returns>
        public ActionResult SaveSolution(string ID, string Solution)
        {
            var tmpService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").SaveSolution(ID, Solution);
            if (tmpService.IsSuccess)
                return View();
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }

        /// <summary>
        /// 完成案件
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult FinishCase(string ID)
        {
            var tmpService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").FinishCase(ID);
            if (tmpService.IsSuccess)
                return View();
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }
    }
}
