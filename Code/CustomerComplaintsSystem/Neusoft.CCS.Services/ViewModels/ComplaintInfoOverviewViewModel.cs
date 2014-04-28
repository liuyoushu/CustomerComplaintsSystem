using System;

namespace Neusoft.CCS.Services.ViewModels
{
    /// <summary>
    /// 投诉处理总览视图模型
    /// </summary>
    public class ComplaintInfoOverviewViewModel
    {
        /// <summary>
        /// 投诉ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string ComplainerName { get; set; }
        /// <summary>
        /// 投诉业务
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// 投诉方式
        /// </summary>
        public string Way { get; set; }
        /// <summary>
        /// 投诉日期
        /// </summary>
        public DateTime Date { get; set; }
    }
}
