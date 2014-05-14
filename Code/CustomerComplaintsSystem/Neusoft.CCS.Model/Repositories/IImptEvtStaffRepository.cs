using Neusoft.CCS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IImptEvtStaffRepository
    {
        bool Create(ImportantEvent_Staff imptEvtCenter);

        Dictionary<int, ComplaintInfo> RetrieveList();

        ImportantEvent_Staff RetrieveById(int id);

        bool Update(ImportantEvent_Staff imptEvtStaff);
    }
}
