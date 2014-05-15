using System.Linq;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using System.Collections.Generic;

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


        public System.Collections.Generic.Dictionary<string, string> RetrieveListWithChargingBizName()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var query = (from staff in context.Staffs
                             join position in context.Positions on staff.Post_ID equals position.Post_ID
                             join biz in context.Businesses on staff.BussinessID equals biz.BussinessID
                             where position.Post_SuperiorID < 0
                             select new { LeaderId = staff.Stf_ID, BizName = biz.BussinessName });
                result = query.ToDictionary(s => s.LeaderId, s => s.BizName);
            }

            return result;
        }


        public Dictionary<string, string> RetrieveListBySuperiorPositionId(int positionId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var staffs = (from position in context.Positions
                                     where position.Post_SuperiorID == positionId
                                     select position).FirstOrDefault().Staffs;
                //var query = (from staff in context.Staffs
                //             where staff.Post_ID == positionQuery.Post_ID
                //             select new { StaffId = staff.Stf_ID, StaffName = staff.Stf_Name });
                //result = query.ToDictionary(s => s.StaffId, s => s.StaffName);
                result = staffs.ToDictionary(s => s.Stf_ID, s => s.Stf_Name);
            }
            return result;
        }


        public Model.Entities.Staff RetrieveByIdAndPwd(string staffId, string pwd)
        {
            Model.Entities.Staff result = new Model.Entities.Staff();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var staff = (from item in context.Staffs
                             where item.Stf_ID == staffId && item.Stf_Password == pwd
                             select item).FirstOrDefault();
                result =  staff.ToModel();
            }
            return result;
        }
    }
}
