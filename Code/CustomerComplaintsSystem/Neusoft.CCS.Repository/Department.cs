//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neusoft.CCS.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Department
    {
        public Department()
        {
            this.Companies = new HashSet<Company>();
        }
    
        public int DepartmentID { get; set; }
        public int BussinessID { get; set; }
        public string DepartmentName { get; set; }
        public string Describe { get; set; }
        public string DepartmentPhoneNum { get; set; }
        public string DepartmentRemark { get; set; }
    
        public virtual Business Business { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}