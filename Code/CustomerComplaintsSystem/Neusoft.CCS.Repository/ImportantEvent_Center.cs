//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neusoft.CCS.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImportantEvent_Center
    {
        public ImportantEvent_Center()
        {
            this.ImportantEvent_Department = new HashSet<ImportantEvent_Department>();
        }
    
        public int IptEvt_C_ID { get; set; }
        public string Stf_ID { get; set; }
        public int ID { get; set; }
        public string IptEvt_C_Solution { get; set; }
        public Nullable<System.DateTime> IptEvt_C_BeginDate { get; set; }
        public Nullable<System.DateTime> IptEvt_C_EndDate { get; set; }
        public string IptEvt_C_Conclusion { get; set; }
    
        public virtual CaseInfo CaseInfo { get; set; }
        public virtual ICollection<ImportantEvent_Department> ImportantEvent_Department { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
