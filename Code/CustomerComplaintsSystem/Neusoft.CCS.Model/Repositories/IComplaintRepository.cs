using Neusoft.CCS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IComplaintRepository
    {
        int CreateComplaint(CaseInfo caseInfo, Complainer complainer, ComplaintInfo complaintInfo);
        List<string> GetAllBusinesses();
        List<ComplaintInfo> RetrieveComplaintInfoByUserEmail(string name, string email);
        List<ComplaintInfo> RetrieveComplaintInfoByUserPhone(string name, string phone);
        List<History> GetHistoriesByID(string ID);
        ComplaintDisposeAndFeedbackInfo GetSolutionByID(string ID);
        ComplaintInfo GetComplaintInfoByID(string ID); 
        int SaveSolution(string ID, string Solution);
        int FinishCase(string ID, DateTime finishTime);
    }
}
