using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Neusoft.CCS.Services.ViewModels
{
    /// <summary>
    /// 投诉回访单
    /// </summary>
    public class ReturnVisitFormViewModel
    {
        /// <summary>
        /// 案件编号
        /// </summary>
        public int CaseID { get; set; }


        /// <summary>
        /// 投诉时间
        /// </summary>
        [DisplayName("投诉时间")]
        //[DataType(DataType.DateTime)]
        public DateTime ComplaintDate { get; set; }
        /// <summary>
        /// 投诉类别
        /// </summary>
        [DisplayName("投诉类别")]
        //[DataType(DataType.Text)]
        public string Class { get; set; }
        /// <summary>
        /// 投诉问题描述
        /// </summary>
        [DisplayName("投诉问题描述")]
        //[DataType(DataType.Text)]
        public string Describe { get; set; }
        /// <summary>
        /// 业务名
        /// </summary>
        [DisplayName("业务名")]
        //[DataType(DataType.Text)]
        public string Name { get; set; }


        /// <summary>
        /// 客户满意度
        /// </summary>
        [DisplayName("客户满意度")]
        //[DataType(DataType.Text)]
        public string Satisfaction { get; set; }


        /// <summary>
        /// 投诉回访信息编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 回访时间
        /// </summary>
        [DisplayName("投诉类别")]
        [DataType(DataType.DateTime)]
        public DateTime ReturnVisitDate { get; set; }
        /// <summary>
        /// 回访内容
        /// </summary>
        [DisplayName("回访内容")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        /// <summary>
        /// 问题本身是否解决
        /// </summary>
        [DisplayName("问题本身是否解决")]
        //[DataType(DataType.Text)]
        public bool IsSolved { get; set; }
        /// <summary>
        /// 处理不满原因
        /// </summary>
        [DisplayName("处理不满原因")]
        [DataType(DataType.MultilineText)]
        public string ComplaintReason { get; set; }
        /// <summary>
        /// 回访开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 回访结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
