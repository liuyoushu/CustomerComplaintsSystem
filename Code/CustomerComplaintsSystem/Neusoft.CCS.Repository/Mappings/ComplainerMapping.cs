using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.Complainer与业务实体Model.Entities.Complainer的映射关系
    /// </summary>
    public static class ComplainerMapping
    {
        /// <summary>
        /// 数据实体Repository.Complainer到业务实体Model.Entities.Complainer的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.Complainer</param>
        /// <returns>业务实体Model.Entities.Complainer</returns>
        public static Model.Entities.Complainer ToModel(this Complainer dataEntity)
        {
            Neusoft.CCS.Model.Entities.Complainer Complainer = null;
            if (dataEntity != null)
            {
                Complainer = new Model.Entities.Complainer()
                {
                    ID = dataEntity.ID,
                    Name = dataEntity.Name,
                    Email = dataEntity.Email,
                    PhoneNumber = dataEntity.PhoneNumber,                    
                };
            }
            return Complainer;
        }

        /// <summary>
        /// 数据实体集合List_Repository.Complainer到业务实体集合List_Model.Entities.Complainer的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.Complainer</param>
        /// <returns>业务实体集合List_Model.Entities.Complainer</returns>
        public static List<Model.Entities.Complainer> ToModels(this List<Complainer> entities)
        {
            List<Model.Entities.Complainer> result = new List<Model.Entities.Complainer>();
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
        /// 业务实体Model.Entities.Complainer到数据实体Repository.Complainer的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.Complainer</param>
        /// <returns>数据实体Repository.Complainer</returns>
        public static Complainer ToDataEntity(this Model.Entities.Complainer model)
        {
            Complainer dataEntity = null;
            if (model != null)
            {
                dataEntity = new Complainer()
                {
                    ID = model.ID,
                    Name = model.Name,
                    Email = model.Name,
                    PhoneNumber = model.PhoneNumber
                };
            }
            return dataEntity;
        }
    }
}
