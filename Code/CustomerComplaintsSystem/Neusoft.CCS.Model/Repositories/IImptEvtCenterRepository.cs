using Neusoft.CCS.Model.Entities;
using System.Collections.Generic;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IImptEvtCenterRepository
    {
        bool Create(ImportantEvent_Center imptEvtCenter);
        Dictionary<int, ComplaintInfo> RetrieveList();
        ImportantEvent_Center RetrieveById(int id);
    }
}
