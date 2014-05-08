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
    public class ImptEvtCenterService : IImptEvtCenterService
    {
        private IComplaintReturnVisitInfoRepository _cptRVInfoRepository;
        private IComplaintDisposeAndFeedbackInfoRepository _cptDAFInfoRepository;
        private IComplaintInfoRepository _cptInfoRepository;
        private ICaseInfoRepository _caseInfoRepository;
        private IImptEvtCenterRepository _imptEvtCenterRepository;
        private IImptEvtDeptRepository _imptEvtDeptRepository;
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
            _imptEvtDeptRepository = DI.SpringHelper.GetObject<IImptEvtDeptRepository>("ImptEvtDeptRepository");

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


        /// <summary>
        /// 保存重大事件（中心）处理单
        /// </summary>
        /// <param name="imptEvtCenterForm"></param>
        /// <returns></returns>
        public bool SubmitImptEvtCenterForm(ImptEvtCenterFormViewModel imptEvtCenterForm)
        {
            //imptEvtCenterForm.EndTime = DateTime.Now;//记录结束时间

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

        /// <summary>
        /// 读取业务部门名称及其第一负责人名
        /// </summary>
        /// <returns></returns>
        public LoadingBizNameWithLeaderIdResponse LoadingBizNameWithLeaderId(int id)
        {
            LoadingBizNameWithLeaderIdResponse result = new LoadingBizNameWithLeaderIdResponse();
            result.BizNameWithLeaderId = new DepartmentResponsibilitiesViewModel();

            var imptEvtCenter = _imptEvtCenterRepository.RetrieveById(id);


            result.BizNameWithLeaderId.ImptEvtCenterID = imptEvtCenter.ID;
            result.BizNameWithLeaderId.CaseID = imptEvtCenter.CaseInfo.ID;

            result.BizNameWithLeaderId.BizNameWithLeaderId = _staffRepository.RetrieveListWithChargingBizName();


            result.IsSuccess = true;
            return result;
        }


        public bool DecideResponsibilities(DepartmentResponsibilitiesViewModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.DutyA))
                {
                    this.CreteImptEvtDept(model.LeaderIdA, model.ImptEvtCenterID, model.CaseID, model.DutyA);
                }

                if (!string.IsNullOrEmpty(model.DutyB))
                {
                    this.CreteImptEvtDept(model.LeaderIdB, model.ImptEvtCenterID, model.CaseID, model.DutyB);
                }

                if (!string.IsNullOrEmpty(model.DutyC))
                {
                    this.CreteImptEvtDept(model.LeaderIdC, model.ImptEvtCenterID, model.CaseID, model.DutyC);
                }

                if (!string.IsNullOrEmpty(model.DutyD))
                {
                    this.CreteImptEvtDept(model.LeaderIdD, model.ImptEvtCenterID, model.CaseID, model.DutyD);
                }

                if (!string.IsNullOrEmpty(model.DutyE))
                {
                    this.CreteImptEvtDept(model.LeaderIdE, model.ImptEvtCenterID, model.CaseID, model.DutyE);
                }

                if (!string.IsNullOrEmpty(model.DutyF))
                {
                    this.CreteImptEvtDept(model.LeaderIdF, model.ImptEvtCenterID, model.CaseID, model.DutyF);
                }

                //TODO:next step

                CaseInfo caseInfo = _caseInfoRepository.RetrieveById(model.CaseID);
                //更新案件状态
                caseInfo.State = Model.Entities.CaseState.ImptEvt_DeptDecided;//更新案件状态至部门间沟通协调完毕

                //更新案件信息状态
                _caseInfoRepository.Update(caseInfo);
            }
            catch (Exception ex)
            {
                _logger.Error(this, "部门间沟通协调失败", ex);
                return false;
            }



            return true;

        }

        private void CreteImptEvtDept(string staffId, int imptEvtCenterId, int caseId, string duty)
        {
            Model.Entities.ImportantEvent_Department imptEvtDept = new Model.Entities.ImportantEvent_Department()
            {
                Duty = duty
            };
            imptEvtDept.CaseInfo = _caseInfoRepository.RetrieveById(caseId);
            imptEvtDept.Staff = _staffRepository.RetrieveById(staffId);
            imptEvtDept.ImportantEvent_Center = _imptEvtCenterRepository.RetrieveById(imptEvtCenterId);

            _imptEvtDeptRepository.Create(imptEvtDept);
        }
    }
}
