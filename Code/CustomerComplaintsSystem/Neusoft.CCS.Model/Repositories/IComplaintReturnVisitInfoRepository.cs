using System.Collections.Generic;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IComplaintReturnVisitInfoRepository
    {
        List<ComplaintInfo> RetrieveReturnVistingList();
        ComplaintReturnVisitInfo RetrieveById(int id);
    }
}
