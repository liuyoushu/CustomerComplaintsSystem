using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 公司
    /// </summary>
    public class Company
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所在省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 所在市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 所在县
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailedAddress { get; set; }
        /// <summary>
        /// 上级公司ID
        /// </summary>
        public int SuperiorCompany { get; set; }

        /// <summary>
        /// 下属部门
        /// </summary>
        public List<Department> Departments { get; set; }
    }
}
