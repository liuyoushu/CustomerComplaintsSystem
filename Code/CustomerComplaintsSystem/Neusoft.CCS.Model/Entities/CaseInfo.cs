using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 案件信息
    /// </summary>
    public class CaseInfo
    {
        /// <summary>
        /// 案件编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 案件归档时间日期
        /// </summary>
        public DateTime ArchiveDate { get; set; }
        /// <summary>
        /// 案件状态
        /// </summary>
        public CaseState State { get; set; }

        /// <summary>
        /// 案件投诉者
        /// </summary>
        public Complainer Complainer { get; set; }
    }
}
