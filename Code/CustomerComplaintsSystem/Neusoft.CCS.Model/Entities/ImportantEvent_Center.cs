using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 重大事件（中心）处理信息
    /// </summary>
    public class ImportantEvent_Center
    {
        /// <summary>
        /// 重大事件（中心）处理信息ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 总解决方案
        /// </summary>
        public string Solution { get; set; }
        /// <summary>
        /// 处理开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 处理结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 处理总结
        /// </summary>
        public string Conclusion { get; set; }

        /// <summary>
        /// 案件信息
        /// </summary>
        public CaseInfo CaseInfo { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public Staff Staff { get; set; }
        ///// <summary>
        ///// 相关重大事件（部门）处理单
        ///// </summary>
        //public List<ImportantEvent_Department> ImportantEvent_Departments { get; set; }
    }
}
