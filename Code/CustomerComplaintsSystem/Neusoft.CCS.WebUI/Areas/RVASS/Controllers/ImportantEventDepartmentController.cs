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

        public ActionResult AllocateTaskForStaff(int id)
        {
            var response = DI.SpringHelper.GetObject<IImptEvtDeptService>("ImptEvtDeptService").LoadingImptEvtDeptForm(id);

            //1.2将数据封装到 SelectList中，并指定 要生成下拉框选项的 value 和 text 属性
            SelectList complaintHandlerNameWithStaffId = new SelectList(response.ImptEvtDeptForm.ComplaintHandlerNameWithStaffId, "Key", "Value");
            ViewData["complaintHandlerNameWithStaffId"] = complaintHandlerNameWithStaffId.AsEnumerable();
            return View(response);
        }
    }
}
