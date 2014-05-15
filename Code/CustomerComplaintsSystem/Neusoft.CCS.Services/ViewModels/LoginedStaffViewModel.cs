using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Services.ViewModels
{
    public class LoginedStaffViewModel
    {
        /// <summary>
        /// 工号
        /// </summary>
        /// <example>员工工号 为 “00100100001”的形式。
        /// 前三位为公司编号，中间三位为部门编号，最后5位为员工号。</example>
        [DisplayName("工号")]
        [DataType(DataType.Text)]
        public string ID { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        [DisplayName("姓名")]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [DataType(DataType.Text)]
        public string Password { get; set; }

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

        public List<Permission> Permissions { get; set; }
    }
}
