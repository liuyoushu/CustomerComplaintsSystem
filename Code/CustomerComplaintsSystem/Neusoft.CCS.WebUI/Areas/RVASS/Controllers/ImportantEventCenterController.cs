﻿using System;
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

        /// <summary>
        /// 读取重大事件（中心）处理单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult ImportantEventtHanding(int id)
        {
            var response = DI.SpringHelper.GetObject<IImptEvtCenterService>("ImptEvtCenterService").LoadingImptEvtCenterForm(id);
            if (!response.IsSuccess)
            {
                Response.Write("<script>alert('" + response.ErrorMessage + "')</script>");
            }
            return PartialView(response.ImptEvtCenterForm);
        }

        /// <summary>
        /// 保存重大事件（中心）处理单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportantEventtHanding(ImptEvtCenterFormViewModel model)
        {
            if (!DI.SpringHelper.GetObject<IImptEvtCenterService>("ImptEvtCenterService").SubmitImptEvtCenterForm(model))
            {
                Response.Write("<script>alert('提交重大事件（中心）处理单失败！')</script>");
            }

            if (model.IsHandled)//已经处理完毕
                return RedirectToAction("ImportantEventBox", "ImportantEventCenterController");
            else
                return RedirectToAction("DecideResponsibilities", "ImportantEventCenterController", new { id = model.ImptEvtCenterID });
        }

        public PartialViewResult DecideResponsibilities(int id)
        {
        }
    }
}
