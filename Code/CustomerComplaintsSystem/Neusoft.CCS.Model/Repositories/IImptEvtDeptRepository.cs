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
    }
}
