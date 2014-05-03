using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.ViewModels
{
    public class RetrieveComplaintInfoByUserViewModel
    {
        public int ID { get; set; }
        public string ComplainerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public string Way { get; set; }
        public DateTime Date { get; set; }
        public string Class { get; set; }
    }
}
