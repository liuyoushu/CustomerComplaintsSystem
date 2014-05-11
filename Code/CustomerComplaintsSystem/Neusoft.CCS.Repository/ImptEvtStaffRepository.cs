using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Infrastructure.Logging;
using System.Data.Entity.Infrastructure;

namespace Neusoft.CCS.Repository
{
    public class ImptEvtStaffRepository : IImptEvtStaffRepository
    {
        private ILogger _logger;

        public ImptEvtStaffRepository()
        {
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        public bool Create(Model.Entities.ImportantEvent_Staff imptEvtStaff)
        {
            var model = imptEvtStaff.ToDataEntity();
            try
            {
                using (NeusoftCCSEntities context = new NeusoftCCSEntities())
                {
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.ImportantEvent_Staff.Add(model);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(this, "ImportantEvent_Staff Create Error", ex);
                return false;
            }

            return true;
        }


        public Dictionary<int, Model.Entities.ComplaintInfo> RetrieveList()
        {
            Dictionary<int, Model.Entities.ComplaintInfo> result = new Dictionary<int, Model.Entities.ComplaintInfo>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var imptEvtDeptList = (from item in context.ImportantEvent_Staff
                                       join caseInfo in context.CaseInfoes on item.ID equals caseInfo.ID
                                       where (caseInfo.State == ((int)CaseState.ImptEvt_StaffAllocated)
                                             && string.IsNullOrEmpty(item.IptEvt_S_Content))
                                       //&& item.Stf_ID == staffId)
                                       select item).ToList();
                foreach (var imptEvt in imptEvtDeptList)
                {
                    var cptInfo = (from item in context.ComplaintInfoes
                                   where item.ID == imptEvt.CaseInfo.ID
                                   orderby item.Cpt_EndTime descending
                                   select item).FirstOrDefault().ToModel();
                    result.Add(imptEvt.IptEvt_D_ID, cptInfo);
                }
            }
            return result;
        }
    }
}
