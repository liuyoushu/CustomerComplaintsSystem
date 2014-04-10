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
    public class ComplaintInfoRepository:IComplaintInfoRepository
    {
        public List<Model.Entities.ComplaintInfo> GetNotArchivedComplaintInfoList(int startIndex, int requestCount)
        {
            List<Model.Entities.ComplaintInfo> result = new List<Model.Entities.ComplaintInfo>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entities = (from cpt in context.ComplaintInfoes
                                where cpt.CaseInfo.State != 99
                                orderby cpt.Cpt_Date descending
                                select cpt);
                result = entities.Skip(startIndex).Take(requestCount).ToList().ToModels();
            }
            return result;
        }
    }
}
