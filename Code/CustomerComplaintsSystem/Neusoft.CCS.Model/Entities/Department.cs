using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部门描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 部门联系电话
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// 业务ID
        /// </summary>
        public int BusinessID { get; set; }
    }
}
