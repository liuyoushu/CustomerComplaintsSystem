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


        public LoadingImptEvtStaffFormResponse LoadingImptEvtStaffForm(int id)
        {
            LoadingImptEvtStaffFormResponse result = new LoadingImptEvtStaffFormResponse();
            var imptEvtStaff = _imptEvtStaffRepository.RetrieveById(id);
            var cptRVInfo = _cptRVInfoRepository.RetrieveListByCaseId(imptEvtStaff.CaseInfo.ID).First();
            var cptDAFInfo = _cptDAFInfoRepository.RetrieveListByCaseId(imptEvtStaff.CaseInfo.ID).First();
            var cptInfo = _cptInfoRepository.RetrieveListByCaseId(imptEvtStaff.CaseInfo.ID).First();
            if (cptInfo != null && cptDAFInfo != null && cptDAFInfo != null && imptEvtStaff != null)
            {

                result.ImptEvtStaffForm = imptEvtStaff.ToImptEvtStaffViewModel();
                result.ImptEvtStaffForm.BeginTime = DateTime.Now;//记录重大事件（员工）处理开始时间
                //重大事件（中心）处理单的其他项
                result.ImptEvtStaffForm.ComplaintDate = cptInfo.Date;
                result.ImptEvtStaffForm.Class = cptInfo.Class;
                result.ImptEvtStaffForm.Describe = cptInfo.Describe;
                result.ImptEvtStaffForm.Name = cptInfo.Business.Name;
                result.ImptEvtStaffForm.Satisfaction = cptDAFInfo.SatisfactionToString();
                result.ImptEvtStaffForm.ReturnVisitContent = cptRVInfo.Content;
                result.ImptEvtStaffForm.ComplaintReason = cptRVInfo.ComplaintReason;


                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = "读取重大事件（员工）处理单错误";
            }
            return result;
        }


        public bool ImptEvtHandled(ImptEvtStaffFormViewModel imptEvtStaffForm)
        {
            imptEvtStaffForm.EndTime = DateTime.Now;//记录结束时间

            Model.Entities.ImportantEvent_Staff imptEvtStaff = imptEvtStaffForm.ImptEvtStaffViewModelToEntity();//转换为业务对象
            imptEvtStaff.CaseInfo = _caseInfoRepository.RetrieveById(imptEvtStaffForm.CaseID);//查询出相应案件信息

            //imptEvtDept.CaseInfo.ImptEvtWaitHandledCounter--;

            if (imptEvtStaff.CaseInfo.ImptEvtWaitHandledCounter <= 0)
            {
                imptEvtStaff.CaseInfo.State = CaseState.ImptEvt_Handled;
            }




            try
            {
                _caseInfoRepository.Update(imptEvtStaff.CaseInfo);
                _imptEvtStaffRepository.Update(imptEvtStaff);

            }
            catch (Exception ex)
            {
                _logger.Error(this, "指派受理员处理重大事件失败", ex);
                return false;
            }

            try
            {
                //TODO:发送邮件给客户反馈结果
            }
            catch (Exception ex)
            {
                _logger.Error(this, "发送邮件失败", ex);
                return false;
            }

            return true;
        }
    }
}
