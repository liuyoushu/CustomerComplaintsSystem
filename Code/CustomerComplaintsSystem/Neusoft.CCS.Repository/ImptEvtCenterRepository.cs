using System;
using System.Collections.Generic;
using System.Linq;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Infrastructure.Logging;
using System.Data.Entity.Infrastructure;

namespace Neusoft.CCS.Repository
{
    public class ImptEvtCenterRepository : IImptEvtCenterRepository
    {
        private ILogger _logger;

        public ImptEvtCenterRepository()
        {
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        public bool Create(Model.Entities.ImportantEvent_Center imptEvtCenter)
        {
            var model = imptEvtCenter.ToDataEntity();
            try
            {
                using (NeusoftCCSEntities context = new NeusoftCCSEntities())
                {
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.ImportantEvent_Center.Add(model);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(this, "ImportantEvent_Center Create Error", ex);
                return false;
            }

            return true;
        }


        public Dictionary<int, Model.Entities.ComplaintInfo> RetrieveList()
        {
            Dictionary<int, Model.Entities.ComplaintInfo> result = new Dictionary<int, Model.Entities.ComplaintInfo>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var imptEvtCenterList = (from item in context.ImportantEvent_Center
                                         join caseInfo in context.CaseInfoes on item.ID equals caseInfo.ID
                                         where (caseInfo.State == ((int)CaseState.ImportantEvent))
                                         select item).ToList();
                foreach (var imptEvt in imptEvtCenterList)
                {
                    var cptInfo = (from item in context.ComplaintInfoes
                                   where item.ID == imptEvt.CaseInfo.ID
                                   orderby item.Cpt_EndTime descending
                                   select item).FirstOrDefault().ToModel();
                    result.Add(imptEvt.IptEvt_C_ID, cptInfo);
                }
            }
            return result;
        }



        public Model.Entities.ImportantEvent_Center RetrieveById(int id)
        {
            Model.Entities.ImportantEvent_Center result = new Model.Entities.ImportantEvent_Center();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entity = (from item in context.ImportantEvent_Center
                              where item.IptEvt_C_ID == id
                              select item);
                result = entity.FirstOrDefault().ToModel();
            }
            return result;
        }
    }
}
