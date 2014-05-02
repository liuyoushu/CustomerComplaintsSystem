using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Services.ViewModels;

namespace Neusoft.CCS.Services.Interfaces
{
    public interface IComplaintReturnVisitInfoService
    {
        /// <summary>
        /// 读取待回访列表
        /// </summary>
        /// <returns></returns>
        LoadingReturnVisitBoxResponse LoadingReturnVisitBox();

        /// <summary>
        /// 读取投诉回访单
        /// </summary>
        /// <returns></returns>
        LoadingReturnVisitFormResponse LoadingReturnVisitForm(int id);

        /// <summary>
        /// 提交投诉回访单
        /// </summary>
        /// <param name="rvForm"></param>
        /// <returns></returns>
        bool SubmitReturnVisitForm(ReturnVisitFormViewModel rvForm);
    }
}
