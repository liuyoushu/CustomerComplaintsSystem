using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 历史记录
    /// </summary>
    public class History
    {
        /// <summary>
        /// 历史记录ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 处理过程
        /// </summary>
        public string Process { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime HandleTime { get; set; }

        /// <summary>
        /// 案件信息
        /// </summary>
        public CaseInfo CaseInfo { get; set; }
        /// <summary>
        /// 经手员工
        /// </summary>
        public Staff Staff { get; set; }
    }
}
