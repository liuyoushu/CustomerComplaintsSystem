using System.Collections.Generic;
using System.Linq;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Repository
{
    public class ComplaintInfoRepository:IComplaintInfoRepository
    {
        public List<Model.Entities.ComplaintInfo> GetNotArchivedComplaintInfoList()
        {
            List<Model.Entities.ComplaintInfo> result = new List<Model.Entities.ComplaintInfo>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entities = (from cpt in context.ComplaintInfoes
                                where cpt.CaseInfo.State != ((int)(CaseState.Archived))
                                orderby cpt.Cpt_Date descending
                                select cpt);
                //result = entities.Skip(startIndex).Take(requestCount).ToList().ToModels();
                result = entities.ToList().ToModels();
            }
            return result;
        }

        public Model.Entities.ComplaintInfo GetDetailedInfoById(int id)
        {
            Model.Entities.ComplaintInfo result = new Model.Entities.ComplaintInfo();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entity = (from cpt in context.ComplaintInfoes
                              where cpt.ID == id
                              select cpt).FirstOrDefault();
                result = entity.ToModel();
            }
            return result;
        }
    }
}
