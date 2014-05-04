using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Services.Mappings;
using Neusoft.CCS.Services.ViewModels;
using System;

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




        public LoadingImptEvtCenterFormResponse LoadingImptEvtCenterForm(int id)
        {
            LoadingImptEvtCenterFormResponse result = new LoadingImptEvtCenterFormResponse();
            var imptEvtCenter = _imptEvtCenterRepository.RetrieveById(id);
            var cptRVInfo = _cptRVInfoRepository.RetrieveById(id);
            var cptDAFInfo = _cptDAFInfoRepository.RetrieveListByCaseId(cptRVInfo.CaseInfo.ID).First();
            var cptInfo = _cptInfoRepository.RetrieveListByCaseId(cptRVInfo.CaseInfo.ID).First();
            if (cptInfo != null && cptDAFInfo != null && cptDAFInfo != null && imptEvtCenter != null)
            {

            }
            throw new NotImplementedException();
        }
    }
}
