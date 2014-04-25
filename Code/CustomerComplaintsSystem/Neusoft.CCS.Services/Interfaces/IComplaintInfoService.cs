using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Services.Messages;

namespace Neusoft.CCS.Services.Interfaces
{
    /// <summary>
    /// 案件信息服务接口
    /// </summary>
    public interface IComplaintInfoService
    {
        /// <summary>
        /// 获取所有尚未归档的投诉案件
        /// </summary>
        /// <returns></returns>
        ComplaintInfoOverviewResponse GetNotArchivedComplaintInfo();
    }
}
