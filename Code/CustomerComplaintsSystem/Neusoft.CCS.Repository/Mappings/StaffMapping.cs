using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.Staff与业务实体Model.Entities.Staff的映射关系
    /// </summary>
    public static class StaffMapping
    {
        /// <summary>
        /// 数据实体Repository.Staff到业务实体Model.Entities.Staff的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.Staff</param>
        /// <returns>业务实体Model.Entities.Staff</returns>
        public static Model.Entities.Staff ToModel(this Staff dataEntity)
        {
            Neusoft.CCS.Model.Entities.Staff Staff = null;
            if (dataEntity != null)
            {
                Staff = new Model.Entities.Staff()
                {
                    ID = dataEntity.Stf_ID,
                    Name = dataEntity.Stf_Name,
                    Gender = dataEntity.Stf_Gender == 0?"女":"男",


                };
            }
            return Staff;
        }

        /// <summary>
        /// 数据实体集合List_Repository.Staff到业务实体集合List_Model.Entities.Staff的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.Staff</param>
        /// <returns>业务实体集合List_Model.Entities.Staff</returns>
        public static List<Model.Entities.Staff> ToModels(this List<Staff> entities)
        {
            List<Model.Entities.Staff> result = new List<Model.Entities.Staff>();
            if (entities != null && entities.Count > 0)
            {
                foreach (var entity in entities)
                {
                    var model = entity.ToModel();
                    if (model != null)
                    {
                        result.Add(model);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 业务实体Model.Entities.Staff到数据实体Repository.Staff的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.Staff</param>
        /// <returns>数据实体Repository.Staff</returns>
        public static Staff ToDataEntity(this Model.Entities.Staff model)
        {
            Staff dataEntity = null;
            if (model != null)
            {
                dataEntity = new Staff()
                {
                    StaffID = model.ID,
                    StaffName = model.Name,
                    Describe = model.Describe,
                    StaffPhoneNum = model.PhoneNumber,
                    StaffRemark = model.Remark
                };
            }
            return dataEntity;
        }
    }
}

