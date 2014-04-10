using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.Department与业务实体Model.Entities.Department的映射关系
    /// </summary>
    public static class DepartmentMapping
    {
        /// <summary>
        /// 数据实体Repository.Department到业务实体Model.Entities.Department的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.Department</param>
        /// <returns>业务实体Model.Entities.Department</returns>
        public static Model.Entities.Department ToModel(this Department dataEntity)
        {
            Neusoft.CCS.Model.Entities.Department Department = null;
            if (dataEntity != null)
            {
                Department = new Model.Entities.Department()
                {
                    ID = dataEntity.DepartmentID,
                    Name = dataEntity.DepartmentName,
                    Describe = dataEntity.Describe,
                    PhoneNumber = dataEntity.DepartmentPhoneNum,
                    Remark = dataEntity.DepartmentRemark,

                    Businesses = new List<Model.Entities.Business>(),
                };
            }
            return Department;
        }

        /// <summary>
        /// 数据实体集合List_Repository.Department到业务实体集合List_Model.Entities.Department的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.Department</param>
        /// <returns>业务实体集合List_Model.Entities.Department</returns>
        public static List<Model.Entities.Department> ToModels(this List<Department> entities)
        {
            List<Model.Entities.Department> result = new List<Model.Entities.Department>();
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
        /// 业务实体Model.Entities.Department到数据实体Repository.Department的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.Department</param>
        /// <returns>数据实体Repository.Department</returns>
        public static Department ToDataEntity(this Model.Entities.Department model)
        {
            Department dataEntity = null;
            if (model != null)
            {
                dataEntity = new Department()
                {
                    DepartmentID = model.ID,
                    DepartmentName = model.Name,
                    Describe = model.Describe,
                    DepartmentPhoneNum = model.PhoneNumber,
                    DepartmentRemark = model.Remark                    
                };
            }
            return dataEntity;
        }
    }
}
