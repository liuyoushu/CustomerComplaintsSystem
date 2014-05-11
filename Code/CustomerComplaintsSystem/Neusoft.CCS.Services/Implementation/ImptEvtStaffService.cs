using Neusoft.CCS.Services.Interfaces;
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
    public class ImptEvtStaffService : IImptEvtStaffService
    {
        private IComplaintReturnVisitInfoRepository _cptRVInfoRepository;
        private IComplaintDisposeAndFeedbackInfoRepository _cptDAFInfoRepository;
        private IComplaintInfoRepository _cptInfoRepository;
        private ICaseInfoRepository _caseInfoRepository;
        private IImptEvtCenterRepository _imptEvtCenterRepository;
        private IImptEvtDeptRepository _imptEvtDeptRepository;
        private IImptEvtStaffRepository _imptEvtStaffRepository;
        private IStaffRepository _staffRepository;
        private ILogger _logger;

        public ImptEvtStaffService()
        {
            _cptRVInfoRepository = DI.SpringHelper.GetObject<IComplaintReturnVisitInfoRepository>("ComplaintReturnVisitInfoRepository");
            _cptDAFInfoRepository = DI.SpringHelper.GetObject<IComplaintDisposeAndFeedbackInfoRepository>("ComplaintDisposeAndFeedbackInfoRepository");
            _cptInfoRepository = DI.SpringHelper.GetObject<IComplaintInfoRepository>("ComplaintInfoRepository");
            _caseInfoRepository = DI.SpringHelper.GetObject<ICaseInfoRepository>("CaseInfoRepository");
            _imptEvtCenterRepository = DI.SpringHelper.GetObject<IImptEvtCenterRepository>("ImptEvtCenterRepository");
            _staffRepository = DI.SpringHelper.GetObject<IStaffRepository>("StaffRepository");
            _imptEvtDeptRepository = DI.SpringHelper.GetObject<IImptEvtDeptRepository>("ImptEvtDeptRepository");
            _imptEvtStaffRepository = DI.SpringHelper.GetObject<IImptEvtStaffRepository>("ImptEvtStaffRepository");

            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        public LoadingImptEventBoxForStaffResponse LoadingImptEventBoxForStaff()
        {
            LoadingImptEventBoxForStaffResponse result = new LoadingImptEventBoxForStaffResponse();
            var cptInfoDict = _imptEvtStaffRepository.RetrieveList();
            //TODO:移除不属于当前员工的cptInfo
            if (cptInfoDict != null && cptInfoDict.Count > 0)
            {
                result.IsSuccess = true;
                result.ImptEventBoxForStaff = cptInfoDict.ToBoxViewModels();
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
    }
}
