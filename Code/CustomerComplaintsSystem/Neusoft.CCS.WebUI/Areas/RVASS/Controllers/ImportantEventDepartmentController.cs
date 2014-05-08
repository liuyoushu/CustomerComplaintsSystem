using System.Web;
using System.Web.Mvc;
using Neusoft.CCS.Services.Implementation;
using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.ViewModels;
using Neusoft.CCS.Services.Mappings;

namespace Neusoft.CCS.WebUI.Areas.RVASS.Controllers
{
    public class ImportantEventDepartmentController : Controller
    {
        //
        // GET: /RVASS/ImportantEventDepartment/


        /// <summary>
        /// 重大事件（中心）处理单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ImportantEventBox()
        {
            var response = DI.SpringHelper.GetObject<IImptEvtDeptService>("ImptEvtDeptService").LoadingImptEventBoxForDept();//staffId
            //if (!response.IsSuccess)
            //{
            //    Response.Write("<script>alert('" + response.ErrorMessage + "')</script>");
            //}
            return View(response);
        }
    }
}
