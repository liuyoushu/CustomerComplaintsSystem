using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Services.Mappings;
using Neusoft.CCS.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Entities;


namespace Neusoft.CCS.Services.Implementation
{
    public class ComplaintService : IComplaintService
    {
        private IComplaintRepository _complaintRepository;
        private ILogger _logger;
        public ComplaintService()
        {
            _complaintRepository = DI.SpringHelper.GetObject<IComplaintRepository>("ComplaintRepository");    
        }
        public CreateComplaintResponse CreateComplaint(CreateComplaintViewModel request)
        {
            var result = _complaintRepository.CreateComplaint(request.ToCaseInfo(), request.ToComplainer(), request.ToComplaintInfo());
                //new Model.Entities.CaseInfo() 
                //{ 
                //    State = Model.Entities.CaseState.Start 
                //},
                //new Model.Entities.Complainer() 
                //{ 
                //    Name = request.Cmp_Name, 
                //    PhoneNumber = request.Phone, 
                //    Email = request.Email 
                //},
                //new Model.Entities.ComplaintInfo() 
                //{ 
                //    Way = request.Way, 
                //    Area = request.Cmp_Area, 
                //    Describe = request.Describe, 
                //    Class = request.Class, 
                //    Date = request.Date 
                //});
            Messages.CreateComplaintResponse response = new Messages.CreateComplaintResponse();
            if (result > 0)
            {
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "新建投诉案件错误";
            }
            return response;
        }


        public GetAllBusinessesResponse GetAllBusinesses()
        {
            GetAllBusinessesResponse response = new GetAllBusinessesResponse();
            response.AllBusinesses = new CreateComplaintViewModel();
            response.AllBusinesses.Businesses = _complaintRepository.GetAllBusinesses();
            if (response.AllBusinesses.Businesses != null && response.AllBusinesses.Businesses.Count > 0)
            {
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "获取所有业务失败";
            }
            return response;
        }


        public GetComplaintByUserResponse GetComplaintByUser(string name, string phone, string email)
        {
            GetComplaintByUserResponse response = new GetComplaintByUserResponse();
            response.ComplaintOverView = new List<RetrieveComplaintInfoByUserViewModel>();
            List<ComplaintInfo> result = null;
            if(string.IsNullOrEmpty(phone))
                result = _complaintRepository.RetrieveComplaintInfoByUserEmail(name,email);
            else
                result = _complaintRepository.RetrieveComplaintInfoByUserPhone(name, phone);
            if (result != null && result.Count > 0)
            {
                response.ComplaintOverView = result.ToRetrieveComplaintInfoesByUser();
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "根据客户获取投诉信息错误";
            }
            return response;
        }


        public GetComplaintDetailByIDResponse GetComplaintDetailByID(string ID)
        {
            GetComplaintDetailByIDResponse response = new GetComplaintDetailByIDResponse();
            response.CaseDetail = new ComplaintHandlingDetailInfoViewModel();
            ComplaintInfo complaintInfo = _complaintRepository.GetComplaintInfoByID(ID);
            if (complaintInfo != null)
            {
                response.CaseDetail.BasicInfo = complaintInfo.ToRetrieveComplaintInfoByUser();
                response.CaseDetail.Describe = complaintInfo.Describe;
                response.CaseDetail.Comment = complaintInfo.Comment;
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "获取案件基本信息错误";
            }
            ComplaintDisposeAndFeedbackInfo solution = _complaintRepository.GetSolutionByID(ID);
            if (solution != null)
                response.CaseDetail.Solution = solution.Solution;
            List<History> histories = _complaintRepository.GetHistoriesByID(ID);
            if (histories != null && histories.Count > 0)
            {
                List<string> processes = new List<string>();
                foreach (var item in histories)
                {
                    processes.Add(item.Staff.Name + "  " + item.Process + "  " + item.HandleTime.ToShortDateString());
                }
                response.CaseDetail.Process = string.Join("\r\n", processes);
            }
            return response;
        }


        public SaveSolutionResponse SaveSolution(string ID, string Solution)
        {
            SaveSolutionResponse response = new SaveSolutionResponse();
            int result = _complaintRepository.SaveSolution(ID, Solution);
            if (result > 0)
                response.IsSuccess = true;
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "保存解决方案错误";
            }
            return response;
        }

        public FinishCaseResponse FinishCase(string ID)
        {
            FinishCaseResponse response = new FinishCaseResponse();
            int result = _complaintRepository.FinishCase(ID, DateTime.Now);
            if (result > 0)
                response.IsSuccess = true;
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "保存完成案件错误";
            }
            return response;
        }
    }
}
