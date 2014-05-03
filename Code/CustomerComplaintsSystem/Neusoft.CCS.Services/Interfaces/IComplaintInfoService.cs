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

        /// <summary>
        /// 获取投诉信息详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ComplaintInfoDetailResponse Detailed(int id);
    }
}
