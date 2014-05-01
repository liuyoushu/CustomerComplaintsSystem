using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Services.Mappings;

namespace Neusoft.CCS.Services.Implementation
{
    public class ComplaintInfoService: IComplaintInfoService
    {
        private IComplaintInfoRepository _complaintInfoRepository;
        private ILogger _logger;

        public ComplaintInfoService()
        {
            //使用Spring.Net进行DI
            _complaintInfoRepository = DI.SpringHelper.GetObject<IComplaintInfoRepository>("ComplaintInfoRepository");
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        /// <summary>
        /// 获取所有尚未归档的投诉案件
        /// </summary>
        /// <returns></returns>
        public ComplaintInfoOverviewResponse GetNotArchivedComplaintInfo()
        {
            ComplaintInfoOverviewResponse result = new ComplaintInfoOverviewResponse();
            var cptInfo = _complaintInfoRepository.GetNotArchivedComplaintInfoList();
            if (cptInfo != null && cptInfo.Count >= 0)
            {
                result.IsSuccess = true;
                result.NotArchivedComplaint = cptInfo.ToOverviewViewModels();
            }
            return result;
        }

        /// <summary>
        /// 获取案件详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ComplaintInfoDetailResponse Detailed(int id)
        {
            ComplaintInfoDetailResponse result = new ComplaintInfoDetailResponse();
            var cptInfo = _complaintInfoRepository.GetDetailedInfoById(id);
            if (cptInfo != null)
            {
                result.IsSuccess = true;
                result.DetailedComplaintInfo = cptInfo.ToDetailViewModel();
            }
            return result;
        }
    }
}
