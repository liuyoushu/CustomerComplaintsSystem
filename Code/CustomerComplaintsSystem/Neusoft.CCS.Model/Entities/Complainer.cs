using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 客户/投诉者
    /// </summary>
    public class Complainer
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 电子邮箱地址
        /// </summary>
        public string Email { get; set; }
    }
}
