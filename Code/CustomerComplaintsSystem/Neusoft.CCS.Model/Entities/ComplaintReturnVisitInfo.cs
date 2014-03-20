using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 投诉回访信息
    /// </summary>
    public class ComplaintReturnVisitInfo
    {
        /// <summary>
        /// 投诉回访信息编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 回访时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 回访内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 问题本身是否解决
        /// </summary>
        public bool IsSolved { get; set; }
        /// <summary>
        /// 处理不满原因
        /// </summary>
        public string ComplaintReason { get; set; }
        /// <summary>
        /// 回访开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 回访结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 案件信息
        /// </summary>
        public CaseInfo CaseInfo { get; set; }
        /// <summary>
        /// 员工信息
        /// </summary>
        public Staff Staff { get; set; }
    }
}
