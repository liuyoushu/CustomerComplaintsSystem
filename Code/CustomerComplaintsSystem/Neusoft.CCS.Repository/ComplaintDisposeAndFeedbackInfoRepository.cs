using Neusoft.CCS.Model.Repositories;
using System.Linq;
using Neusoft.CCS.Repository.Mappings;
using System.Collections.Generic;

namespace Neusoft.CCS.Repository
{
    public class ComplaintDisposeAndFeedbackInfoRepository : IComplaintDisposeAndFeedbackInfoRepository
    {

        public List<Model.Entities.ComplaintDisposeAndFeedbackInfo> RetrieveListByCaseId(int caseId)
        {
            List<Model.Entities.ComplaintDisposeAndFeedbackInfo> result = new List<Model.Entities.ComplaintDisposeAndFeedbackInfo>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entities = (from cptDAFInfo in context.ComplaintDisposeAndFeedbackInfoes
                                where cptDAFInfo.ID == caseId
                                orderby cptDAFInfo.CptDF_EndTime descending
                                select cptDAFInfo);
                result = entities.ToList().ToModels();
            }
            return result;
        }
    }
}
