using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.Company与业务实体Model.Entities.Company的映射关系
    /// </summary>
    public static class CompanyMapping
    {
        /// <summary>
        /// 数据实体Repository.Company到业务实体Model.Entities.Company的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.Company</param>
        /// <returns>业务实体Model.Entities.Company</returns>
        public static Model.Entities.Company ToModel(this Company dataEntity)
        {
            Neusoft.CCS.Model.Entities.Company Company = null;
            if (dataEntity != null)
            {
                Company = new Model.Entities.Company()
                {
                    ID = dataEntity.CompanyID,
                    Name = dataEntity.CompanyName,
                    Province = dataEntity.CompanyName,
                    City = dataEntity.City,
                    County = dataEntity.County,
                    DetailedAddress = dataEntity.DetailedAddress,
                    SuperiorCompany = dataEntity.SuperiorComID.Value,

                    Departments = new List<Model.Entities.Department>(),
                };
            }
            return Company;
        }

        /// <summary>
        /// 数据实体集合List_Repository.Company到业务实体集合List_Model.Entities.Company的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.Company</param>
        /// <returns>业务实体集合List_Model.Entities.Company</returns>
        public static List<Model.Entities.Company> ToModels(this List<Company> entities)
        {
            List<Model.Entities.Company> result = new List<Model.Entities.Company>();
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
        /// 业务实体Model.Entities.Company到数据实体Repository.Company的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.Company</param>
        /// <returns>数据实体Repository.Company</returns>
        public static Company ToDataEntity(this Model.Entities.Company model)
        {
            Company dataEntity = null;
            if (model != null)
            {
                dataEntity = new Company()
                {
                   CompanyID = model.ID,
                   CompanyName = model.Name,
                   Province = model.Province,
                   City = model.City,
                   County = model.County,
                   DetailedAddress = model.DetailedAddress,
                   SuperiorComID = model.SuperiorCompany
                };
            }
            return dataEntity;
        }
    }
}
