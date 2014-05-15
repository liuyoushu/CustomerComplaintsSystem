using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    public static class PermissionMapping
    {
        /// <summary>
        /// 数据实体Repository.Position到业务实体Model.Entities.Position的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.Position</param>
        /// <returns>业务实体Model.Entities.Position</returns>
        public static Model.Entities.Permission ToModel(this Permission dataEntity)
        {
            Neusoft.CCS.Model.Entities.Permission Position = null;
            if (dataEntity != null)
            {
                Position = new Model.Entities.Permission()
                {
                    PermissionActionName = dataEntity.PermissionActionName,
                    PermissionCategory = dataEntity.PermissionCategory,
                    PermissionControllerName = dataEntity.PermissionControllerName,
                    PermissionDisplayName = dataEntity.PermissionDisplayName
                };
            }
            return Position;
        }

        /// <summary>
        /// 数据实体集合List_Repository.Position到业务实体集合List_Model.Entities.Position的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.Position</param>
        /// <returns>业务实体集合List_Model.Entities.Position</returns>
        public static List<Model.Entities.Permission> ToModels(this ICollection<Permission> entities)
        {
            List<Model.Entities.Permission> result = new List<Model.Entities.Permission>();
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
        /// 业务实体Model.Entities.Position到数据实体Repository.Position的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.Position</param>
        /// <returns>数据实体Repository.Position</returns>
        public static Permission ToDataEntity(this Model.Entities.Permission model)
        {
            Permission dataEntity = null;
            if (model != null)
            {
                dataEntity = new Permission()
                {
                    PermissionID = model.PermissionId,
                    PermissionActionName = model.PermissionActionName,
                    PermissionCategory = model.PermissionCategory,
                    PermissionControllerName = model.PermissionControllerName,
                    PermissionDisplayName = model.PermissionDisplayName,
                };
            }
            return dataEntity;
        }
    }
}
