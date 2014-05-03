using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 投诉信息
    /// </summary>
    public class ComplaintInfo
    {
        /// <summary>
        /// 投诉信息ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 投诉方式
        /// </summary>
        public string Way { get; set; }
        /// <summary>
        /// 投诉时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 投诉地域
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 投诉类别
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 投诉问题描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 客户评价
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 受理开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 受理结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 案件信息
        /// </summary>
        public CaseInfo CaseInfo { get; set; }
        /// <summary>
        /// 业务
        /// </summary>
        public Business Business { get; set; }
    }
}
