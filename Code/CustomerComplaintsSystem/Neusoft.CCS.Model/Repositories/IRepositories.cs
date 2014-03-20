
 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
	public partial interface IBusinessRepository : IBaseRepository<Business>
    {
    }

	public partial interface ICaseInfoRepository : IBaseRepository<CaseInfo>
    {
    }

	public partial interface ICompanyRepository : IBaseRepository<Company>
    {
    }

	public partial interface IComplainerRepository : IBaseRepository<Complainer>
    {
    }

	public partial interface IComplaintDisposeAndFeedbackInfoRepository : IBaseRepository<ComplaintDisposeAndFeedbackInfo>
    {
    }

	public partial interface IComplaintInfoRepository : IBaseRepository<ComplaintInfo>
    {
    }

	public partial interface IComplaintReturnVisitInfoRepository : IBaseRepository<ComplaintReturnVisitInfo>
    {
    }

	public partial interface IDepartmentRepository : IBaseRepository<Department>
    {
    }

	public partial interface IHistoryRepository : IBaseRepository<History>
    {
    }

	public partial interface IImportantEvent_CenterRepository : IBaseRepository<ImportantEvent_Center>
    {
    }

	public partial interface IImportantEvent_DepartmentRepository : IBaseRepository<ImportantEvent_Department>
    {
    }

	public partial interface IImportantEvent_StaffRepository : IBaseRepository<ImportantEvent_Staff>
    {
    }

	public partial interface IPositionRepository : IBaseRepository<Position>
    {
    }

	public partial interface IStaffRepository : IBaseRepository<Staff>
    {
    }


}