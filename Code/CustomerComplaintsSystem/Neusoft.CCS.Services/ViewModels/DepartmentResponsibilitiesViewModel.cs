using Neusoft.CCS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Neusoft.CCS.Services.ViewModels
{
    public class DepartmentResponsibilitiesViewModel
    {
        /// <summary>
        /// 案件编号
        /// </summary>
        public int CaseID { get; set; }
        /// <summary>
        /// 重大事件（中心）处理信息ID
        /// </summary>
        public int ImptEvtCenterID { get; set; }


        public Dictionary<string, string> BizNameWithLeaderId { get; set; }

        public string LeaderIdA { get; set; }
        [DataType(DataType.Text)]
        public string DutyA { get; set; }

        public string LeaderIdB { get; set; }
        [DataType(DataType.Text)]
        public string DutyB { get; set; }

        
        public string LeaderIdC { get; set; }
        [DataType(DataType.Text)]
        public string DutyC { get; set; }

        public string LeaderIdD { get; set; }
        [DataType(DataType.Text)]
        public string DutyD { get; set; }

        public string LeaderIdE { get; set; }
        [DataType(DataType.Text)]
        public string DutyE { get; set; }

        public string LeaderIdF { get; set; }
        [DataType(DataType.Text)]
        public string DutyF { get; set; }


    }
}
