using Neusoft.CCS.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Repository 
{
    public class ComplaintDisposeAndFeedbackInfoRepository : IComplaintDisposeAndFeedbackInfoRepository
    {
        public Model.Entities.ComplaintDisposeAndFeedbackInfo RetrieveById(int id)
        {
            Model.Entities.ComplaintDisposeAndFeedbackInfo result = new Model.Entities.ComplaintDisposeAndFeedbackInfo();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entity = (from cptDAFInfo in context.ComplaintDisposeAndFeedbackInfoes
                                  where cptDAFInfo.ID == id
                                  select cptDAFInfo);
                result = entity.FirstOrDefault().ToModel();
            }
            return result;
        }
    }
}
