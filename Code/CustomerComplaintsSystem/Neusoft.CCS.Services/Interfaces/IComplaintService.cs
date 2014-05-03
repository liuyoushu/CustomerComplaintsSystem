using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.Interfaces
{
    /// <summary>
    /// 投诉处理对外service接口
    /// </summary>
    public interface IComplaintService
    {
        /// <summary>
        /// 发起投诉
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateComplaintResponse CreateComplaint(CreateComplaintViewModel request);

        /// <summary>
        /// 获取所有业务
        /// </summary>
        /// <returns></returns>
        GetAllBusinessesResponse GetAllBusinesses();

        /// <summary>
        /// 根据客户获取投诉案件信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        GetComplaintByUserResponse GetComplaintByUser(string name, string phone, string email);

        /// <summary>
        /// 获取案件详细信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        GetComplaintDetailByIDResponse GetComplaintDetailByID(string ID);

        /// <summary>
        /// 保存解决方案
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Solution"></param>
        /// <returns></returns>
        SaveSolutionResponse SaveSolution(string ID, string Solution);

        /// <summary>
        /// 完成案件处理
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        FinishCaseResponse FinishCase(string ID);
    }
}
