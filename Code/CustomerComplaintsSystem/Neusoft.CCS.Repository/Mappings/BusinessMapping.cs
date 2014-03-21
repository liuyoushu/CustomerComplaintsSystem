using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.Business与业务实体Model.Entities.Business的映射关系
    /// </summary>
    public static class BusinessMapping
    {
        /// <summary>
        /// 数据实体Repository.Business到业务实体Model.Entities.Business的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.Business</param>
        /// <returns>业务实体Model.Entities.Business</returns>
        public static Model.Entities.Business ToModel(this Business dataEntity)
        {
            Neusoft.CCS.Model.Entities.Business Business = null;
            if (dataEntity != null)
            {
                Business = new Model.Entities.Business()
                {
                    ID = dataEntity.BussinessID,
                    Name = dataEntity.BussinessName,
                    Describe = dataEntity.BussinessDescribe
                };
            }
            return Business;
        }

        /// <summary>
        /// 数据实体集合List_Repository.Business到业务实体集合List_Model.Entities.Business的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.Business</param>
        /// <returns>业务实体集合List_Model.Entities.Business</returns>
        public static List<Model.Entities.Business> ToModels(this List<Business> entities)
        {
            List<Model.Entities.Business> result = new List<Model.Entities.Business>();
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
        /// 业务实体Model.Entities.Business到数据实体Repository.Business的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.Business</param>
        /// <returns>数据实体Repository.Business</returns>
        public static Business ToDataEntity(this Model.Entities.Business model)
        {
            Business dataEntity = null;
            if (model != null)
            {
                dataEntity = new Business()
                {
                    BussinessID = model.ID,
                    BussinessName = model.Name,
                    BussinessDescribe = model.Describe
                };
            }
            return dataEntity;
        }
    }
}
