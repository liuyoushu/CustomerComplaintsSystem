using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Services.Messages;

namespace Neusoft.CCS.Services.Interfaces
{
    public interface IComplaintReturnVisitInfoService
    {
        /// <summary>
        /// 读取待回访列表
        /// </summary>
        /// <returns></returns>
        LoadingReturnVisitBoxResponse LoadingReturnVisitBox();
    }
}
