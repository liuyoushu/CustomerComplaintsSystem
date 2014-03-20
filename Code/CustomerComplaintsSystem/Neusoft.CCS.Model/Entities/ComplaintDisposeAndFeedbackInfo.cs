using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 投诉处理及反馈信息
    /// </summary>
    public class ComplaintDisposeAndFeedbackInfo
    {
        /// <summary>
        /// 反馈信息ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 处理方案
        /// </summary>
        public string Solution { get; set; }
        /// <summary>
        /// 反馈内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 客户满意度
        /// </summary>
        public Satisfaction Satisfaction { get; set; }
        /// <summary>
        /// 处理开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 处理结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 案件信息
        /// </summary>
        public CaseInfo CaseInfo { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public Staff Staff { get; set; }
    }
}
