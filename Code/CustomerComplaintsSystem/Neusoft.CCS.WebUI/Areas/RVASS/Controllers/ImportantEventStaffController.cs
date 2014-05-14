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

namespace Neusoft.CCS.WebUI.Areas.RVASS.Controllers
{
    public class ImportantEventStaffController : Controller
    {
        //
        // GET: /RVASS/ImportantEventStaff/

        /// <summary>
        /// 重大事件（员工）处理单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ImportantEventBox()
        {
            var response = DI.SpringHelper.GetObject<IImptEvtStaffService>("ImptEvtStaffService").LoadingImptEventBoxForStaff();//staffId
            return View(response);
        }


        [HttpGet]
        public ActionResult ImportantEventHandled(int id)
        {
            var response = DI.SpringHelper.GetObject<IImptEvtStaffService>("ImptEvtStaffService").LoadingImptEvtStaffForm(id);
            return View(response);
        }

        [HttpPost]
        public ActionResult ImportantEventHandled(LoadingImptEvtStaffFormResponse model)
        {
            if (!DI.SpringHelper.GetObject<IImptEvtStaffService>("ImptEvtStaffService").ImptEvtHandled(model.ImptEvtStaffForm))
            {
                Response.Write("<script>alert('提交部门间职责信息失败！')</script>");
            }

            return RedirectToAction("ImportantEventBox", "ImportantEventDepartment");
        }

    }
}
