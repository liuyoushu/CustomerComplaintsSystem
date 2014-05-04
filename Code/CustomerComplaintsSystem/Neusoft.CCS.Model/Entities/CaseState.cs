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
        //重大事件相关
        ImportantEvent = 60,
        ImptEvt_DeptDecided = 61,
        ImptEvt_StaffAllocated = 62,
        ImptEvt_Handled = 63,

        Rehandling = 70,

        ReturnVisiting = 80,
        ReturnVisitFailed = 81,

        

        Archived = 99,
    }
}
