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
    public class ComplaintReturnVisitInfoService : IComplaintReturnVisitInfoService
    {
        private IComplaintReturnVisitInfoRepository _cptRVInfoRepository;
        private IComplaintDisposeAndFeedbackInfoRepository _cptDAFInfoRepository;
        private IComplaintInfoRepository _cptInfoRepository;
        private ICaseInfoRepository _caseInfoRepository;
        private IImptEvtCenterRepository _imptEvtCenterRepository;
        private IStaffRepository _staffRepository;
        private ILogger _logger;

        public ComplaintReturnVisitInfoService()
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
        /// 读取待回访列表
        /// </summary>
        /// <returns></returns>
        public LoadingReturnVisitBoxResponse LoadingReturnVisitBox()
        {
            LoadingReturnVisitBoxResponse result = new LoadingReturnVisitBoxResponse();
            var cptRVDict = _cptRVInfoRepository.RetrieveReturnVistingList();
            if (cptRVDict != null && cptRVDict.Count >= 0)
            {
                result.IsSuccess = true;
                result.RetrunVisitBox = cptRVDict.ToBoxViewModels();
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
            var cptRVInfo = _cptRVInfoRepository.RetrieveById(id);
            var cptDAFInfo = _cptDAFInfoRepository.RetrieveListByCaseId(cptRVInfo.CaseInfo.ID).First();
            var cptInfo = _cptInfoRepository.RetrieveListByCaseId(cptRVInfo.CaseInfo.ID).First();
            if (cptRVInfo != null && cptDAFInfo != null && cptInfo != null)
            {
                
                result.ReturnVisitForm = cptRVInfo.ToReturnVisitFormViewModel();
                result.ReturnVisitForm.BeginTime = DateTime.Now;//记录开始回访时间
                //投诉回访单的其他项
                result.ReturnVisitForm.ComplaintDate = cptInfo.Date;
                result.ReturnVisitForm.Class = cptInfo.Class;
                result.ReturnVisitForm.Describe = cptInfo.Describe;
                result.ReturnVisitForm.Name = cptInfo.Business.Name;
                result.ReturnVisitForm.Satisfaction = cptDAFInfo.SatisfactionToString();

                result.IsSuccess = true;
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
            rvForm.ReturnVisitDate = DateTime.Now;//记录回访时间
            rvForm.EndTime = DateTime.Now;//记录结束时间

            Model.Entities.ComplaintReturnVisitInfo cptRVinfo = rvForm.ReturnVisitFormToEntity();//转换为业务对象
            Model.Entities.CaseInfo caseInfo = _caseInfoRepository.RetrieveById(rvForm.CaseID);//查询出相应案件信息

            try
            {
                #region 投诉反馈回访流程决策
                //投诉反馈回访流程决策
                if (rvForm.IsSolved)//问题已解决
                {
                    caseInfo.ArchiveDate = DateTime.Now;
                    caseInfo.State = Model.Entities.CaseState.Archived;

                    //更新案件信息状态
                    _caseInfoRepository.Update(caseInfo);
                    //保存投诉反馈回访单
                    _cptRVInfoRepository.Update(cptRVinfo);
                }
                else if (!rvForm.IsSolved && caseInfo.UnsatisfiedWithSolution < 3)//问题没解决，且对解决方案不满意不足3次 → 重新进行投诉处理
                {
                    //更新案件状态
                    caseInfo.State = Model.Entities.CaseState.Rehandling;//重新进行投诉处理
                    caseInfo.UnsatisfiedWithSolution++;//对解决办法不满意

                    //更新案件信息状态
                    _caseInfoRepository.Update(caseInfo);
                    //保存投诉反馈回访单
                    _cptRVInfoRepository.Update(cptRVinfo);
                }
                else if (!rvForm.IsSolved && caseInfo.UnsatisfiedWithSolution >= 3)//问题没解决，且对解决方案不满意3次及以上 → 升级为重大事件
                {
                    //更新案件状态
                    caseInfo.State = Model.Entities.CaseState.ImportantEvent;//升级为重大事件
                    caseInfo.UnsatisfiedWithSolution++;

                    //更新案件信息状态
                    _caseInfoRepository.Update(caseInfo);
                    //保存投诉反馈回访单
                    _cptRVInfoRepository.Update(cptRVinfo);

                    #region 创建 重大事件（中心）处理单
                    //创建 重大事件（中心）处理单
                    Model.Entities.ImportantEvent_Center imptEvtCenter = new Model.Entities.ImportantEvent_Center();
                    imptEvtCenter.CaseInfo = caseInfo;
                    imptEvtCenter.Staff = _staffRepository.RetrieveById("12345678900"); //TODO:全局登录Staff对象
                    _imptEvtCenterRepository.Create(imptEvtCenter); 
                    #endregion

                }
                #endregion
            }
            catch (Exception ex)
            {
                _logger.Error(this, "投诉反馈回访单提交失败", ex);
                return false;
            }




            return true;
        }
    }
}
