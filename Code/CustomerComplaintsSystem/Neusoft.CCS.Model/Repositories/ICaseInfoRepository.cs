
using System.Collections.Generic;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
    public interface ICaseInfoRepository
    {
        bool Update(CaseInfo caseInfo);
        CaseInfo RetrieveById(int id);
    }
}
