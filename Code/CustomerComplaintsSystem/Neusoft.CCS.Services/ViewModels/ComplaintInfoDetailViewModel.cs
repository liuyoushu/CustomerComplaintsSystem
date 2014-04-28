using System;
using System.ComponentModel;

namespace Neusoft.CCS.Services.ViewModels
{
    /// <summary>
    /// 投诉案件督促视图模型
    /// </summary>
    public class ComplaintInfoDetailViewModel
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        [DisplayName("客户姓名")]
        public string ComplainerName { get; set; }
        /// <summary>
        /// 客户联系电话
        /// </summary>
        [DisplayName("客户联系电话")]
        public string ComplainerPhoneNumber { get; set; }
        /// <summary>
        /// 客户联系邮箱
        /// </summary>
        [DisplayName("客户联系邮箱")]
        public string ComplainerEmail { get; set; }

        /// <summary>
        /// 投诉业务
        /// </summary>
        [DisplayName("投诉业务")]
        public string BusinessName { get; set; }
        /// <summary>
        /// 投诉业务描述
        /// </summary>
        [DisplayName("投诉业务描述")]
        public string BusinessDescribe { get; set; }

        /// <summary>
        /// 投诉方式
        /// </summary>
        [DisplayName("投诉方式")]
        public string Way { get; set; }
        /// <summary>
        /// 投诉时间
        /// </summary>
        [DisplayName("投诉时间")]
        public DateTime Date { get; set; }
        /// <summary>
        /// 投诉类别
        /// </summary>
        [DisplayName("投诉类别")]
        public string Class { get; set; }
        /// <summary>
        /// 投诉问题描述
        /// </summary>
        [DisplayName("投诉问题描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 受理开始时间
        /// </summary>
        [DisplayName("受理开始时间")]
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 受理结束时间
        /// </summary>
        [DisplayName("受理结束时间")]
        public DateTime EndTime { get; set; }


    }
}
