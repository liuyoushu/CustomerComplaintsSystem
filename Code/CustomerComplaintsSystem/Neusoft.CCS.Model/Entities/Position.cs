using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 职位
    /// </summary>
    public class Position
    {
        /// <summary>
        /// 职位ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 工作内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 上级职位ID
        /// </summary>
        public int SuperiorID { get; set; }

        /// <summary>
        /// 该职位员工
        /// </summary>
        public List<Staff> Staffs { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
