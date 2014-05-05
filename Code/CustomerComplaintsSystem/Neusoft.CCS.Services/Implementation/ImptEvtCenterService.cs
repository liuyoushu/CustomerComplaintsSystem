using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Services.Mappings;
using Neusoft.CCS.Services.ViewModels;
using System;
using System.Linq;

namespace Neusoft.CCS.Services.Implementation
{
    public class ImptEvtCenterService : IImptEvtCenterService
    {
        private IComplaintReturnVisitInfoRepository _cptRVInfoRepository;
        private IComplaintDisposeAndFeedbackInfoRepository _cptDAFInfoRepository;
        private IComplaintInfoRepository _cptInfoRepository;
        private ICaseInfoRepository _caseInfoRepository;
        private IImptEvtCenterRepository _imptEvtCenterRepository;
        private IStaffRepository _staffRepository;
        private ILogger _logger;

        public ImptEvtCenterService()
        {
            _cptRVInfoRepository = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoRepository>("ComplaintReturnVisitInfoRepository");
            _cptDAFInfoRepository = DI.SpringHelper.GetObject<IComplaintDisposeAndFeedbackInfoRepository>("ComplaintDisposeAndFeedbackInfoRepository");
            _cptInfoRepository = DI.SpringHelper.GetObject<IComplaintInfoRepository>("ComplaintInfoRepository");
            _caseInfoRepository = DI.SpringHelper.GetObject<ICaseInfoRepository>("CaseInfoRepository");
            _imptEvtCenterRepository = DI.SpringHelper.GetObject<IImptEvtCenterRepository>("ImptEvtCenterRepository");
            _staffRepository = DI.SpringHelper.GetObject<IStaffRepository>("StaffRepository");
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }


        /// <summary>
        /// 读取重大事件（中心）处理单列表
        /// </summary>
        /// <returns></returns>
        public LoadingImptEventBoxForCenterResponse LoadingImptEventBoxForCenter()
        {
            LoadingImptEventBoxForCenterResponse result = new LoadingImptEventBoxForCenterResponse();
            var cptInfoDict = _imptEvtCenterRepository.RetrieveList();
            if (cptInfoDict != null && cptInfoDict.Count >= 0)
            {
                result.IsSuccess = true;
                result.ImptEventBoxForCenter = cptInfoDict.ToBoxViewModels();
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = "读取回访信息错误";
            }
            return result;
        }



        /// <summary>
        /// 读取重大事件（中心）处理单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LoadingImptEvtCenterFormResponse LoadingImptEvtCenterForm(int id)
        {
            LoadingImptEvtCenterFormResponse result = new LoadingImptEvtCenterFormResponse();
            var imptEvtCenter = _imptEvtCenterRepository.RetrieveById(id);
            var cptRVInfo = _cptRVInfoRepository.RetrieveListByCaseId(imptEvtCenter.CaseInfo.ID).First();
            var cptDAFInfo = _cptDAFInfoRepository.RetrieveListByCaseId(imptEvtCenter.CaseInfo.ID).First();
            var cptInfo = _cptInfoRepository.RetrieveListByCaseId(imptEvtCenter.CaseInfo.ID).First();
            if (cptInfo != null && cptDAFInfo != null && cptDAFInfo != null && imptEvtCenter != null)
            {

                result.ImptEvtCenterForm = imptEvtCenter.ToImptEvtCenterViewModel();
                result.ImptEvtCenterForm.BeginTime = DateTime.Now;//记录重大事件（中心）处理开始时间
                //重大事件（中心）处理单的其他项
                result.ImptEvtCenterForm.ComplaintDate = cptInfo.Date;
                result.ImptEvtCenterForm.Class = cptInfo.Class;
                result.ImptEvtCenterForm.Describe = cptInfo.Describe;
                result.ImptEvtCenterForm.Name = cptInfo.Business.Name;
                result.ImptEvtCenterForm.Satisfaction = cptDAFInfo.SatisfactionToString();
                result.ImptEvtCenterForm.Content = cptRVInfo.Content;
                result.ImptEvtCenterForm.ComplaintReason = cptRVInfo.ComplaintReason;

                result.ImptEvtCenterForm.IsHandled = imptEvtCenter.CaseInfo.State == Model.Entities.CaseState.ImportantEvent ? false : true;

                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = "读取重大事件（中心）处理单错误";
            }
            return result;
        }


        public bool SubmitImptEvtCenterForm(ImptEvtCenterFormViewModel imptEvtCenterForm)
        {
            imptEvtCenterForm.EndTime = DateTime.Now;//记录结束时间

            Model.Entities.ImportantEvent_Center imptEvtCenter = imptEvtCenterForm.ImptEvtCenterViewModelToEntity();//转换为业务对象
            imptEvtCenter.CaseInfo = _caseInfoRepository.RetrieveById(imptEvtCenterForm.CaseID);//查询出相应案件信息

            try
            {
                _imptEvtCenterRepository.Update(imptEvtCenter);
            }
            catch (Exception ex)
            {
                _logger.Error(this, "重大事件（中心）提交失败", ex);
                return false;
            }

            return true;
        }
    }
}
