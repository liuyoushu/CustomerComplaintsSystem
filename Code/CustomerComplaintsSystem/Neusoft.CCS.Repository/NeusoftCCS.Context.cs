﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NeusoftCCSEntities : DbContext
    {
        public NeusoftCCSEntities()
            : base("name=NeusoftCCSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Business> Businesses { get; set; }
        public DbSet<CaseInfo> CaseInfoes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Complainer> Complainers { get; set; }
        public DbSet<ComplaintDisposeAndFeedbackInfo> ComplaintDisposeAndFeedbackInfoes { get; set; }
        public DbSet<ComplaintInfo> ComplaintInfoes { get; set; }
        public DbSet<ComplaintReturnVisitInfo> ComplaintReturnVisitInfoes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<ImportantEvent_Center> ImportantEvent_Center { get; set; }
        public DbSet<ImportantEvent_Department> ImportantEvent_Department { get; set; }
        public DbSet<ImportantEvent_Staff> ImportantEvent_Staff { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}