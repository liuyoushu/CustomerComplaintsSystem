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

namespace Neusoft.CCS.Services.Implementation
{
    public class ComplaintInfoService: IComplaintInfoService
    {
        private ICaseInfoRepository _caseInfoRepository;
        private IComplaintInfoRepository _complaintInforepository;
        private ILogger _logger;

        public ComplaintInfoService()
        {
            //使用StructureMap进行DI
            _caseInfoRepository = ObjectFactory.GetInstance<ICaseInfoRepository>();
            _complaintInforepository = ObjectFactory.GetInstance<IComplaintInfoRepository>();
            _logger = ObjectFactory.GetInstance<ILogger>();
        }

        /// <summary>
        /// 获取所有尚未归档的投诉案件
        /// </summary>
        /// <returns></returns>
        public ComplaintInfoOverviewResponse GetNotArchivedComplaintInfo()
        {
            ComplaintInfoOverviewResponse result = new ComplaintInfoOverviewResponse();
            var cptInfo = _complaintInforepository.GetListBy(c => c.CaseInfo.State != Model.Entities.CaseState.Archived);
            if (cptInfo != null && cptInfo.Count > 0)
            {
                result.IsSuccess = true;
                result.NotArchivedComplaint = cptInfo.ToOverviewViewModels();
            }
            return result;
        }
    }
}
