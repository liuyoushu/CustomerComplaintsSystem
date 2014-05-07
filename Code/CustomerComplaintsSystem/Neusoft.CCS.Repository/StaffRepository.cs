﻿using System.Linq;
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
                             where position.Post_SuperiorID == -1
                             select new { LeaderId = staff.Stf_ID, BizName = biz.BussinessName });
                result = query.ToDictionary(s => s.LeaderId, s => s.BizName);
            }

            return result;
        }
    }
}
