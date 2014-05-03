using System.Linq;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;

namespace Neusoft.CCS.Repository
{
    public class StaffRepository : IStaffRepository
    {
        public Model.Entities.Staff RetrieveById(string id)
        {
            Model.Entities.Staff result = new Model.Entities.Staff();

            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entity = (from item in context.Staffs
                              where item.Stf_ID == id
                              select item).FirstOrDefault();
                result = entity.ToModel();

                return result;
            }
        }
    }
}
