using Neusoft.CCS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IImptEvtDeptRepository
    {
        bool Create(ImportantEvent_Department imptEvtCenter);

        Dictionary<int, ComplaintInfo> RetrieveList();

        ImportantEvent_Department RetrieveById(int id);

        bool Update(ImportantEvent_Department imptEvtDept);
    }
}
