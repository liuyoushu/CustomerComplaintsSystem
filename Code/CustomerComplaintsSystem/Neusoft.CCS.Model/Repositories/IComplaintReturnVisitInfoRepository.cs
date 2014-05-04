using System.Collections.Generic;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IComplaintReturnVisitInfoRepository
    {
        Dictionary<int, ComplaintInfo> RetrieveReturnVistingList();
        ComplaintReturnVisitInfo RetrieveById(int id);
        bool Update(ComplaintReturnVisitInfo cptRVInfo);
        List<ComplaintReturnVisitInfo> RetrieveListByCaseId(int caseId);
    }
}
