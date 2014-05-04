using System.Collections.Generic;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IComplaintInfoRepository
    {
        List<ComplaintInfo> GetNotArchivedComplaintInfoList();
        ComplaintInfo GetDetailedInfoById(int id);
        List<ComplaintInfo> RetrieveListByCaseId(int caseId);
    }
}
