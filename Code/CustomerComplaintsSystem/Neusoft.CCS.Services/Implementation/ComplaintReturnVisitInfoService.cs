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
        private IComplaintReturnVisitInfoRepository _complaintReturnVisitInfoRepository;
        private ILogger _logger;

        public ComplaintReturnVisitInfoService()
        {
            _complaintReturnVisitInfoRepository = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoRepository>("ComplaintReturnVisitInfoRepository");
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        /// <summary>
        /// 读取待回访列表
        /// </summary>
        /// <returns></returns>
        public LoadingReturnVisitBoxResponse LoadingReturnVisitBox()
        {
            LoadingReturnVisitBoxResponse result = new LoadingReturnVisitBoxResponse();
            var cptInfo = _complaintReturnVisitInfoRepository.RetrieveReturnVistingList();
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
    }
}
