using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Staff
    {
        /// <summary>
        /// 工号
        /// </summary>
        /// <example>员工工号 为 “00100100001”的形式。
        /// 前三位为公司编号，中间三位为部门编号，最后5位为员工号。</example>
        public string ID { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentifyCardNumber { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime EntryTime { get; set; }


        /// <summary>
        /// 负责业务
        /// </summary>
        public Business Business { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public Position Position { get; set; }

    }
}
