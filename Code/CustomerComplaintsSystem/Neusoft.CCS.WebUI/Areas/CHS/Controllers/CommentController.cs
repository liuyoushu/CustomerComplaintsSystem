using Neusoft.CCS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neusoft.CCS.WebUI.Areas.CHS.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /CHS/Comment/

        public ActionResult Index(string ID)
        {
            var tmpService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").GetComplaintDetailByID(ID);
            if (tmpService.IsSuccess)
            {
                return View("CommentView", tmpService.CaseDetail);
            }
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }
        public ActionResult Comment(string ID, string Comment)
        {
            var tmpService = DI.SpringHelper.GetObject<ICommentService>("CommentService").SaveComment(ID, Comment);
            if (tmpService.IsSuccess)
            {
                return View("CommentView");
            }
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }
        public ActionResult GetAllComment()
        {
            var tmpService = DI.SpringHelper.GetObject<ICommentService>("CommentService").GetCommentedCases();
            if (tmpService.IsSuccess)
            {
                return View("CommentedOverView",tmpService.CommentedCases);
            }
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }
        public ActionResult GetCommentedCaseDetail(string ID)
        {
            var tmpService = DI.SpringHelper.GetObject<IComplaintService>("ComplaintService").GetComplaintDetailByID(ID);
            if (tmpService.IsSuccess)
            {
                return View("CommentedCaseDetailView", tmpService.CaseDetail);
            }
            else
            {
                ViewBag.ErrorMessage = tmpService.ErrorMessage;
                return View("ErrorView");
            }
        }
    }
}
