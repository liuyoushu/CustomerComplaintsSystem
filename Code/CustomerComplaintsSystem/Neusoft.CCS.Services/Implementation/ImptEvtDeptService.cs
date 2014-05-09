﻿using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Services.Mappings;
using Neusoft.CCS.Services.ViewModels;
using System;
using System.Linq;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Services.Implementation
{
    public class ImptEvtDeptService : IImptEvtDeptService
    {
        private IComplaintReturnVisitInfoRepository _cptRVInfoRepository;
        private IComplaintDisposeAndFeedbackInfoRepository _cptDAFInfoRepository;
        private IComplaintInfoRepository _cptInfoRepository;
        private ICaseInfoRepository _caseInfoRepository;
        private IImptEvtCenterRepository _imptEvtCenterRepository;
        private IImptEvtDeptRepository _imptEvtDeptRepository;
        private IStaffRepository _staffRepository;
        private ILogger _logger;

        public ImptEvtDeptService()
        {
            _cptRVInfoRepository = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoRepository>("ComplaintReturnVisitInfoRepository");
            _cptDAFInfoRepository = DI.SpringHelper.GetObject<IComplaintDisposeAndFeedbackInfoRepository>("ComplaintDisposeAndFeedbackInfoRepository");
            _cptInfoRepository = DI.SpringHelper.GetObject<IComplaintInfoRepository>("ComplaintInfoRepository");
            _caseInfoRepository = DI.SpringHelper.GetObject<ICaseInfoRepository>("CaseInfoRepository");
            _imptEvtCenterRepository = DI.SpringHelper.GetObject<IImptEvtCenterRepository>("ImptEvtCenterRepository");
            _staffRepository = DI.SpringHelper.GetObject<IStaffRepository>("StaffRepository");
            _imptEvtDeptRepository = DI.SpringHelper.GetObject<IImptEvtDeptRepository>("ImptEvtDeptRepository");

            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }


        /// <summary>
        /// 读取重大事件（中心）处理单列表
        /// </summary>
        /// <returns></returns>
        public LoadingImptEventBoxForDeptResponse LoadingImptEventBoxForDept()//string staffId
        {
            LoadingImptEventBoxForDeptResponse result = new LoadingImptEventBoxForDeptResponse();
            var cptInfoDict = _imptEvtDeptRepository.RetrieveList();
            //TODO:移除不属于当前员工的cptInfo
            if (cptInfoDict != null && cptInfoDict.Count > 0)
            {
                result.IsSuccess = true;
                result.ImptEventBoxForDept = cptInfoDict.ToBoxViewModels();
            }
            else if (cptInfoDict != null && cptInfoDict.Count == 0)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "尚无重大事件待指派";
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = "读取回访信息错误";
            }
            return result;
        }


        public LoadingImptEvtDeptFormResponse LoadingImptEvtDeptForm(int id)
        {
            LoadingImptEvtDeptFormResponse result = new LoadingImptEvtDeptFormResponse();
            var imptEvtDept = _imptEvtDeptRepository.RetrieveById(id);
            var cptRVInfo = _cptRVInfoRepository.RetrieveListByCaseId(imptEvtDept.CaseInfo.ID).First();
            var cptDAFInfo = _cptDAFInfoRepository.RetrieveListByCaseId(imptEvtDept.CaseInfo.ID).First();
            var cptInfo = _cptInfoRepository.RetrieveListByCaseId(imptEvtDept.CaseInfo.ID).First();
            if (cptInfo != null && cptDAFInfo != null && cptDAFInfo != null && imptEvtDept != null)
            {

                result.ImptEvtDeptForm = imptEvtDept.ToImptEvtCenterViewModel();
                result.ImptEvtDeptForm.BeginTime = DateTime.Now;//记录重大事件（中心）处理开始时间
                //重大事件（中心）处理单的其他项
                result.ImptEvtDeptForm.ComplaintDate = cptInfo.Date;
                result.ImptEvtDeptForm.Class = cptInfo.Class;
                result.ImptEvtDeptForm.Describe = cptInfo.Describe;
                result.ImptEvtDeptForm.Name = cptInfo.Business.Name;
                result.ImptEvtDeptForm.Satisfaction = cptDAFInfo.SatisfactionToString();
                result.ImptEvtDeptForm.Content = cptRVInfo.Content;
                result.ImptEvtDeptForm.ComplaintReason = cptRVInfo.ComplaintReason;

                //本部门员工
                result.ImptEvtDeptForm.ComplaintHandlerNameWithStaffId = _staffRepository.RetrieveListBySuperiorPositionId(imptEvtDept.Staff.Position.ID);


                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = "读取重大事件（中心）处理单错误";
            }
            return result;
        }
    }
}
