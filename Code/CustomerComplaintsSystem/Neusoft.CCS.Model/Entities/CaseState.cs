using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 案件状态
    /// </summary>
    public enum CaseState
    {
        ImportantEvent = 60,

        Rehandling = 70,

        ReturnVisiting = 80,
        ReturnVisitFailed = 81,

        

        Archived = 99,
    }
}
