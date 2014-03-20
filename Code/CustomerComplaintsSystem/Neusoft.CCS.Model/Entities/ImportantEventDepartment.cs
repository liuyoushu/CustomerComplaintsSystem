using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 重大事件（部门）处理信息
    /// </summary>
    public class ImportantEventDepartment
    {
        /// <summary>
        /// 重大事件（部门）处理信息ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 负责工作
        /// </summary>
        public string Duty { get; set; }
        /// <summary>
        /// 部门处理总结
        /// </summary>
        public string Conclusion { get; set; }
        /// <summary>
        /// 处理开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 处理结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 重大事件（中心）处理信息
        /// </summary>
        public ImportantEventCenter ImportantEventCenter { get; set; }
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
