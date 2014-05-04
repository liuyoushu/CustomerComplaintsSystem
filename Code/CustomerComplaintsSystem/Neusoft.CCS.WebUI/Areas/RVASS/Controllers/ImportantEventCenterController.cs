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
    public class ImportantEventCenterController : Controller
    {
        //
        // GET: /RVASS/ImportantEventCenter/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 重大事件（中心）处理单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ImportantEventBox()
        {
            var response = DI.SpringHelper.GetObject<IImptEvtCenterService>("ImptEvtCenterService").LoadingImptEventBoxForCenter();
            if (!response.IsSuccess)
            {
                Response.Write("<script>alert('" + response.ErrorMessage + "')</script>");
            }
            return View(response.ImptEventBoxForCenter);
        }

        [HttpGet]
        public PartialViewResult ImptEvtHanding(int id)
        {
            var response = DI.SpringHelper.GetObject<IImptEvtCenterService>("ImptEvtCenterService").LoadingImptEvtCenterForm(id);
        }
    }
}
