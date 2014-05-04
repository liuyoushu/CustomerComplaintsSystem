using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Neusoft.CCS.Services.ViewModels
{
    public class ImptEvtCenterFormViewModel
    {
        /// <summary>
        /// 案件编号
        /// </summary>
        public int CaseID { get; set; }
        /// <summary>
        /// 重大事件是否处理完毕标志位
        /// </summary>
        public bool IsHandled { get; set; }


        /// <summary>
        /// 投诉时间
        /// </summary>
        [DisplayName("投诉时间")]
        public DateTime ComplaintDate { get; set; }
        /// <summary>
        /// 投诉类别
        /// </summary>
        [DisplayName("投诉类别")]
        public string Class { get; set; }
        /// <summary>
        /// 投诉问题描述
        /// </summary>
        [DisplayName("投诉问题描述")]
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
        public string Satisfaction { get; set; }


        /// <summary>
        /// 回访内容
        /// </summary>
        [DisplayName("回访内容")]
        public string Content { get; set; }
        /// <summary>
        /// 处理不满原因
        /// </summary>
        [DisplayName("处理不满原因")]
        public string ComplaintReason { get; set; }






        /// <summary>
        /// 重大事件（中心）处理信息ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 总解决方案
        /// </summary>
        [DisplayName("总体解决方案")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "总体解决方案必须填写！", AllowEmptyStrings = false)]//前端模型验证，要求必填
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
        [DisplayName("处理总结")]
        [DataType(DataType.MultilineText)]
        public string Conclusion { get; set; }
    }
}
