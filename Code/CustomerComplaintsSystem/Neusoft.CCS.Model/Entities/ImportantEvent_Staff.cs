using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 重大事件（员工）处理信息
    /// </summary>
    public class ImportantEvent_Staff
    {
        /// <summary>
        /// 重大事件（员工）处理信息编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 处理内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 处理开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 处理结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 重大事件（部门）处理信息
        /// </summary>
        public ImportantEvent_Department ImportantEvent_Department { get; set; }
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
