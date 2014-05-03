using Neusoft.CCS.Services.Interfaces;
using System.Web.Mvc;

namespace Neusoft.CCS.WebUI.Areas.RVASS.Controllers
{
    public class ComplaintInfoController : Controller
    {
        //
        // GET: /RVASS/ComplaintInfo/

        /// <summary>
        /// 投诉处理总览
        /// </summary>
        /// <returns></returns>
        public ActionResult ComplaintOverview()
        {
            var response = DI.SpringHelper.GetObject<IComplaintInfoService>("ComplaintInfoService").GetNotArchivedComplaintInfo();

            if (!response.IsSuccess)
            {
                Response.Write("<script>alert('" + response.ErrorMessage + "')</script>");
            }
            return View(response.NotArchivedComplaint);
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

            if (!response.IsSuccess)
            {
                Response.Write("<script>alert('" + response.ErrorMessage + "')</script>");
            }
            return View(response.DetailedComplaintInfo);
        }

    }
}
