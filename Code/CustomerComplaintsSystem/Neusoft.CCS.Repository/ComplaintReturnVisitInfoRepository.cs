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
    public class ComplaintReturnVisitInfoRepository : IComplaintReturnVisitInfoRepository
    {
        public List<Model.Entities.ComplaintInfo> RetrieveReturnVistingList()
        {
            List<Model.Entities.ComplaintInfo> result = new List<Model.Entities.ComplaintInfo>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entities = (from cpt in context.ComplaintInfoes
                                join cptDAFInfo in context.ComplaintDisposeAndFeedbackInfoes on cpt.ID equals cptDAFInfo.ID
                                join cptRVInfo in context.ComplaintReturnVisitInfoes on cpt.ID equals cptRVInfo.ID
                                where cptDAFInfo.CptDF_Satisfaction == ((int)Satisfaction.Unsatisfied)
                                || cptDAFInfo.CptDF_Satisfaction == ((int)Satisfaction.Normal)
                                select cpt);
                result = entities.ToList().ToModels();
            }

            return result;
        }
    }
}
