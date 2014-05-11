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
            //if (!response.IsSuccess)
            //{
            //    Response.Write("<script>alert('" + response.ErrorMessage + "')</script>");
            //}
            return View(response);
        }

    }
}
