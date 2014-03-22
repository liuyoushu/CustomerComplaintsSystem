
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository;

namespace Neusoft.CCS.Repository
{
	public partial class RepositoriesSession : Neusoft.CCS.Model.Repositories.IRepositoriesSession
    {
		#region 01 数据接口 IBusinessRepository
		IBusinessRepository iBusinessRepository;
		public IBusinessRepository IBusinessRepository
		{
			get
			{
				if(iBusinessRepository==null)
					iBusinessRepository= new BusinessRepository();
				return iBusinessRepository;
			}
			set
			{
				iBusinessRepository= value;
			}
		}
		#endregion

		#region 02 数据接口 ICaseInfoRepository
		ICaseInfoRepository iCaseInfoRepository;
		public ICaseInfoRepository ICaseInfoRepository
		{
			get
			{
				if(iCaseInfoRepository==null)
					iCaseInfoRepository= new CaseInfoRepository();
				return iCaseInfoRepository;
			}
			set
			{
				iCaseInfoRepository= value;
			}
		}
		#endregion

		#region 03 数据接口 ICompanyRepository
		ICompanyRepository iCompanyRepository;
		public ICompanyRepository ICompanyRepository
		{
			get
			{
				if(iCompanyRepository==null)
					iCompanyRepository= new CompanyRepository();
				return iCompanyRepository;
			}
			set
			{
				iCompanyRepository= value;
			}
		}
		#endregion

		#region 04 数据接口 IComplainerRepository
		IComplainerRepository iComplainerRepository;
		public IComplainerRepository IComplainerRepository
		{
			get
			{
				if(iComplainerRepository==null)
					iComplainerRepository= new ComplainerRepository();
				return iComplainerRepository;
			}
			set
			{
				iComplainerRepository= value;
			}
		}
		#endregion

		#region 05 数据接口 IComplaintDisposeAndFeedbackInfoRepository
		IComplaintDisposeAndFeedbackInfoRepository iComplaintDisposeAndFeedbackInfoRepository;
		public IComplaintDisposeAndFeedbackInfoRepository IComplaintDisposeAndFeedbackInfoRepository
		{
			get
			{
				if(iComplaintDisposeAndFeedbackInfoRepository==null)
					iComplaintDisposeAndFeedbackInfoRepository= new ComplaintDisposeAndFeedbackInfoRepository();
				return iComplaintDisposeAndFeedbackInfoRepository;
			}
			set
			{
				iComplaintDisposeAndFeedbackInfoRepository= value;
			}
		}
		#endregion

		#region 06 数据接口 IComplaintInfoRepository
		IComplaintInfoRepository iComplaintInfoRepository;
		public IComplaintInfoRepository IComplaintInfoRepository
		{
			get
			{
				if(iComplaintInfoRepository==null)
					iComplaintInfoRepository= new ComplaintInfoRepository();
				return iComplaintInfoRepository;
			}
			set
			{
				iComplaintInfoRepository= value;
			}
		}
		#endregion

		#region 07 数据接口 IComplaintReturnVisitInfoRepository
		IComplaintReturnVisitInfoRepository iComplaintReturnVisitInfoRepository;
		public IComplaintReturnVisitInfoRepository IComplaintReturnVisitInfoRepository
		{
			get
			{
				if(iComplaintReturnVisitInfoRepository==null)
					iComplaintReturnVisitInfoRepository= new ComplaintReturnVisitInfoRepository();
				return iComplaintReturnVisitInfoRepository;
			}
			set
			{
				iComplaintReturnVisitInfoRepository= value;
			}
		}
		#endregion

		#region 08 数据接口 IDepartmentRepository
		IDepartmentRepository iDepartmentRepository;
		public IDepartmentRepository IDepartmentRepository
		{
			get
			{
				if(iDepartmentRepository==null)
					iDepartmentRepository= new DepartmentRepository();
				return iDepartmentRepository;
			}
			set
			{
				iDepartmentRepository= value;
			}
		}
		#endregion

		#region 09 数据接口 IHistoryRepository
		IHistoryRepository iHistoryRepository;
		public IHistoryRepository IHistoryRepository
		{
			get
			{
				if(iHistoryRepository==null)
					iHistoryRepository= new HistoryRepository();
				return iHistoryRepository;
			}
			set
			{
				iHistoryRepository= value;
			}
		}
		#endregion

		#region 10 数据接口 IImportantEvent_CenterRepository
		IImportantEvent_CenterRepository iImportantEvent_CenterRepository;
		public IImportantEvent_CenterRepository IImportantEvent_CenterRepository
		{
			get
			{
				if(iImportantEvent_CenterRepository==null)
					iImportantEvent_CenterRepository= new ImportantEvent_CenterRepository();
				return iImportantEvent_CenterRepository;
			}
			set
			{
				iImportantEvent_CenterRepository= value;
			}
		}
		#endregion

		#region 11 数据接口 IImportantEvent_DepartmentRepository
		IImportantEvent_DepartmentRepository iImportantEvent_DepartmentRepository;
		public IImportantEvent_DepartmentRepository IImportantEvent_DepartmentRepository
		{
			get
			{
				if(iImportantEvent_DepartmentRepository==null)
					iImportantEvent_DepartmentRepository= new ImportantEvent_DepartmentRepository();
				return iImportantEvent_DepartmentRepository;
			}
			set
			{
				iImportantEvent_DepartmentRepository= value;
			}
		}
		#endregion

		#region 12 数据接口 IImportantEvent_StaffRepository
		IImportantEvent_StaffRepository iImportantEvent_StaffRepository;
		public IImportantEvent_StaffRepository IImportantEvent_StaffRepository
		{
			get
			{
				if(iImportantEvent_StaffRepository==null)
					iImportantEvent_StaffRepository= new ImportantEvent_StaffRepository();
				return iImportantEvent_StaffRepository;
			}
			set
			{
				iImportantEvent_StaffRepository= value;
			}
		}
		#endregion

		#region 13 数据接口 IPositionRepository
		IPositionRepository iPositionRepository;
		public IPositionRepository IPositionRepository
		{
			get
			{
				if(iPositionRepository==null)
					iPositionRepository= new PositionRepository();
				return iPositionRepository;
			}
			set
			{
				iPositionRepository= value;
			}
		}
		#endregion

		#region 14 数据接口 IStaffRepository
		IStaffRepository iStaffRepository;
		public IStaffRepository IStaffRepository
		{
			get
			{
				if(iStaffRepository==null)
					iStaffRepository= new StaffRepository();
				return iStaffRepository;
			}
			set
			{
				iStaffRepository= value;
			}
		}
		#endregion

    }

}