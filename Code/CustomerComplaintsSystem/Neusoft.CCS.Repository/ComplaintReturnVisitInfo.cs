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
    
    public partial class ComplaintReturnVisitInfo
    {
        public int CptReVst_ID { get; set; }
        public int ID { get; set; }
        public string Stf_ID { get; set; }
        public Nullable<System.DateTime> CptReVst_Date { get; set; }
        public string CptReVst_Content { get; set; }
        public Nullable<bool> CptReVst_IsSolved { get; set; }
        public string CptReVst_CptReason { get; set; }
        public Nullable<System.DateTime> CptReVst_BeginTime { get; set; }
        public Nullable<System.DateTime> CptReVst_EndTime { get; set; }
    
        public virtual CaseInfo CaseInfo { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
