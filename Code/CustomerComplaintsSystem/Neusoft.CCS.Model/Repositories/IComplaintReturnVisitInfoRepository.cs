using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IComplaintReturnVisitInfoRepository
    {
        List<ComplaintInfo> RetrieveReturnVistingList();
    }
}
