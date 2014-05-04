using System.Collections.Generic;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IComplaintDisposeAndFeedbackInfoRepository
    {
        List<ComplaintDisposeAndFeedbackInfo> RetrieveListByCaseId(int caseId);
    }
}
