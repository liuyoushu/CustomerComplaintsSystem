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
    
    public partial class Business
    {
        public Business()
        {
            this.ComplaintInfoes = new HashSet<ComplaintInfo>();
            this.Departments = new HashSet<Department>();
            this.Staffs = new HashSet<Staff>();
        }
    
        public int BussinessID { get; set; }
        public string BussinessName { get; set; }
        public string BussinessDescribe { get; set; }
    
        public virtual ICollection<ComplaintInfo> ComplaintInfoes { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
