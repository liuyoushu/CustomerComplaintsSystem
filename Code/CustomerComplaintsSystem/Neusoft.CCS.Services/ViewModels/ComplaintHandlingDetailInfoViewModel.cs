using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.ViewModels
{
    public class ComplaintHandlingDetailInfoViewModel
    {
        public RetrieveComplaintInfoByUserViewModel BasicInfo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Process { get; set; }
        public string Solution { get; set; }
        public string Describe { get; set; }
        public string Comment { get; set; }
    }
}
