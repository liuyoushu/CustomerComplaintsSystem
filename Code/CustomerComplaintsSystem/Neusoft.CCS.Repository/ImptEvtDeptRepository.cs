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
    public class ImptEvtDeptRepository : IImptEvtDeptRepository
    {
        private ILogger _logger;

        public ImptEvtDeptRepository()
        {
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        public bool Create(Model.Entities.ImportantEvent_Department imptEvtDept)
        {
            var model = imptEvtDept.ToDataEntity();
            try
            {
                using (NeusoftCCSEntities context = new NeusoftCCSEntities())
                {
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.ImportantEvent_Department.Add(model);

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
