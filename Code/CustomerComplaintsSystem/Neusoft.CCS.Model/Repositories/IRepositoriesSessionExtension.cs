
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
	public partial interface IRepositoriesSession
    {
		IBusinessRepository IBusinessRepository { get; set; }
		ICaseInfoRepository ICaseInfoRepository { get; set; }
		ICompanyRepository ICompanyRepository { get; set; }
		IComplainerRepository IComplainerRepository { get; set; }
		IComplaintDisposeAndFeedbackInfoRepository IComplaintDisposeAndFeedbackInfoRepository { get; set; }
		IComplaintInfoRepository IComplaintInfoRepository { get; set; }
		IComplaintReturnVisitInfoRepository IComplaintReturnVisitInfoRepository { get; set; }
		IDepartmentRepository IDepartmentRepository { get; set; }
		IHistoryRepository IHistoryRepository { get; set; }
		IImportantEvent_CenterRepository IImportantEvent_CenterRepository { get; set; }
		IImportantEvent_DepartmentRepository IImportantEvent_DepartmentRepository { get; set; }
		IImportantEvent_StaffRepository IImportantEvent_StaffRepository { get; set; }
		IPositionRepository IPositionRepository { get; set; }
		IStaffRepository IStaffRepository { get; set; }
    }

}