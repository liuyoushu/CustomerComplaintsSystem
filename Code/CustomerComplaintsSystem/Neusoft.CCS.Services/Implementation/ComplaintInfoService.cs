using Neusoft.CCS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Services.Mappings;
using Neusoft.CCS.Model.Entities;
using StructureMap;
using Neusoft.CCS.Repository;

namespace Neusoft.CCS.Services.Implementation
{
    public class ComplaintInfoService: IComplaintInfoService
    {
        private IComplaintInfoRepository _complaintInforepository;
        private ILogger _logger;

        public ComplaintInfoService()
        {
            //使用Spring.Net进行DI
            //_complaintInforepository = DI.SpringHelper.GetObject<IComplaintInfoRepository>("ComplaintInfoRepository");
            _complaintInforepository = new ComplaintInfoRepository();
            //_logger = ObjectFactory.GetInstance<ILogger>();
        }

        /// <summary>
        /// 获取所有尚未归档的投诉案件
        /// </summary>
        /// <returns></returns>
        public ComplaintInfoOverviewResponse GetNotArchivedComplaintInfo(int startIndex, int requestCount)
        {
            ComplaintInfoOverviewResponse result = new ComplaintInfoOverviewResponse();
            var cptInfo = _complaintInforepository.GetNotArchivedComplaintInfoList(startIndex, requestCount);
            if (cptInfo != null && cptInfo.Count > 0)
            {
                result.IsSuccess = true;
                result.NotArchivedComplaint = cptInfo.ToOverviewViewModels();
            }
            return result;
        }
    }
}
