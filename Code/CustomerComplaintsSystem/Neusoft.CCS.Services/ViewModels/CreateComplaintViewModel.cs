using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.ViewModels
{
    public class CreateComplaintViewModel
    {
        public string Cmp_Name { get; set; }
        //public int Cmp_BusinessType { get; set; }
        public string Phone { get; set; }
        public string Describe { get; set; }
        public string Email { get; set; }
        public string Cmp_Area { get; set; }
        public string Way { get; set; }
        public string Class { get; set; }
        public DateTime Date { get; set; }
        public List<string> Businesses { get; set; }
    }
}
