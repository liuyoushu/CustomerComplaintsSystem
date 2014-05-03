using System;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using Neusoft.CCS.Infrastructure.Logging;

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
    }
}
