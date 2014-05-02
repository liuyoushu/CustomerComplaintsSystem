using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Services.Mappings;
using Neusoft.CCS.Services.ViewModels;

namespace Neusoft.CCS.Services.Implementation
{
    public class ComplaintReturnVisitInfoService : IComplaintReturnVisitInfoService
    {
        private IComplaintReturnVisitInfoRepository _cptRVInfoRepository;
        private IComplaintDisposeAndFeedbackInfoRepository _cptDAFInfoRepository;
        private IComplaintInfoRepository _cptInfoRepository;
        private ILogger _logger;

        public ComplaintReturnVisitInfoService()
        {
            _cptRVInfoRepository = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoRepository>("ComplaintReturnVisitInfoRepository");
            _cptDAFInfoRepository = DI.SpringHelper.GetObject<IComplaintDisposeAndFeedbackInfoRepository>("ComplaintDisposeAndFeedbackInfoRepository");
            _cptInfoRepository = DI.SpringHelper.GetObject<IComplaintInfoRepository>("ComplaintInfoRepository");
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        /// <summary>
        /// 读取待回访列表
        /// </summary>
        /// <returns></returns>
        public LoadingReturnVisitBoxResponse LoadingReturnVisitBox()
        {
            LoadingReturnVisitBoxResponse result = new LoadingReturnVisitBoxResponse();
            var cptInfo = _cptRVInfoRepository.RetrieveReturnVistingList();
            if (cptInfo != null && cptInfo.Count >= 0)
            {
                result.IsSuccess = true;
                result.RetrunVisitBox = cptInfo.ToOverviewViewModels();
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = "读取回访信息错误";
            }
            return result;

        }

        
        /// <summary>
        /// 读取投诉回访单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LoadingReturnVisitFormResponse LoadingReturnVisitForm(int id)
        {
            LoadingReturnVisitFormResponse result = new LoadingReturnVisitFormResponse();
            var cptInfo = _cptInfoRepository.GetDetailedInfoById(id);
            var cptRVInfo = _cptRVInfoRepository.RetrieveById(id);
            var cptDAFInfo = _cptDAFInfoRepository.RetrieveById(id);
            if (cptRVInfo != null && cptDAFInfo != null && cptInfo != null)
            {
                result.IsSuccess = true;
                result.ReturnVisitForm = cptRVInfo.ToReturnVisitFormViewModel();
                //投诉回访单的其他项
                result.ReturnVisitForm.ComplaintDate = cptInfo.Date;
                result.ReturnVisitForm.Class = cptInfo.Class;
                result.ReturnVisitForm.Describe = cptInfo.Describe;
                result.ReturnVisitForm.Name = cptInfo.Business.Name;
                result.ReturnVisitForm.Satisfaction = cptDAFInfo.SatisfactionToString();
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = "读取投诉回访单错误";
            }
            return result;
        }


        /// <summary>
        /// 提交投诉回访单
        /// </summary>
        /// <param name="rvForm"></param>
        /// <returns></returns>
        public bool SubmitReturnVisitForm(ReturnVisitFormViewModel rvForm)
        {
            throw new System.NotImplementedException();
        }
    }
}
