 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Repository
{
	public partial class BusinessRepository : BaseRepository<Neusoft.CCS.Model.Entities.Business>,Neusoft.CCS.Model.Repositories.IBusinessRepository
    {
    }
	public partial class CaseInfoRepository : BaseRepository<Neusoft.CCS.Model.Entities.CaseInfo>,Neusoft.CCS.Model.Repositories.ICaseInfoRepository
    {
    }
	public partial class CompanyRepository : BaseRepository<Neusoft.CCS.Model.Entities.Company>,Neusoft.CCS.Model.Repositories.ICompanyRepository
    {
    }
	public partial class ComplainerRepository : BaseRepository<Neusoft.CCS.Model.Entities.Complainer>,Neusoft.CCS.Model.Repositories.IComplainerRepository
    {
    }
	public partial class ComplaintDisposeAndFeedbackInfoRepository : BaseRepository<Neusoft.CCS.Model.Entities.ComplaintDisposeAndFeedbackInfo>,Neusoft.CCS.Model.Repositories.IComplaintDisposeAndFeedbackInfoRepository
    {
    }
	public partial class ComplaintInfoRepository : BaseRepository<Neusoft.CCS.Model.Entities.ComplaintInfo>,Neusoft.CCS.Model.Repositories.IComplaintInfoRepository
    {
    }
	public partial class ComplaintReturnVisitInfoRepository : BaseRepository<Neusoft.CCS.Model.Entities.ComplaintReturnVisitInfo>,Neusoft.CCS.Model.Repositories.IComplaintReturnVisitInfoRepository
    {
    }
	public partial class DepartmentRepository : BaseRepository<Neusoft.CCS.Model.Entities.Department>,Neusoft.CCS.Model.Repositories.IDepartmentRepository
    {
    }
	public partial class HistoryRepository : BaseRepository<Neusoft.CCS.Model.Entities.History>,Neusoft.CCS.Model.Repositories.IHistoryRepository
    {
    }
	public partial class ImportantEvent_CenterRepository : BaseRepository<Neusoft.CCS.Model.Entities.ImportantEvent_Center>,Neusoft.CCS.Model.Repositories.IImportantEvent_CenterRepository
    {
    }
	public partial class ImportantEvent_DepartmentRepository : BaseRepository<Neusoft.CCS.Model.Entities.ImportantEvent_Department>,Neusoft.CCS.Model.Repositories.IImportantEvent_DepartmentRepository
    {
    }
	public partial class ImportantEvent_StaffRepository : BaseRepository<Neusoft.CCS.Model.Entities.ImportantEvent_Staff>,Neusoft.CCS.Model.Repositories.IImportantEvent_StaffRepository
    {
    }
	public partial class PositionRepository : BaseRepository<Neusoft.CCS.Model.Entities.Position>,Neusoft.CCS.Model.Repositories.IPositionRepository
    {
    }
	public partial class StaffRepository : BaseRepository<Neusoft.CCS.Model.Entities.Staff>,Neusoft.CCS.Model.Repositories.IStaffRepository
    {
    }
}