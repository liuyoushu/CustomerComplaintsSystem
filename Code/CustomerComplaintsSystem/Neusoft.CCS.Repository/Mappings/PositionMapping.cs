using System.Collections.Generic;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.Position与业务实体Model.Entities.Position的映射关系
    /// </summary>
    public static class PositionMapping
    {
        /// <summary>
        /// 数据实体Repository.Position到业务实体Model.Entities.Position的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.Position</param>
        /// <returns>业务实体Model.Entities.Position</returns>
        public static Model.Entities.Position ToModel(this Position dataEntity)
        {
            Neusoft.CCS.Model.Entities.Position Position = null;
            if (dataEntity != null)
            {
                Position = new Model.Entities.Position()
                {
                    ID = dataEntity.Post_ID,
                    Name = dataEntity.Post_Name,
                    Content = dataEntity.Post_Content,
                    Remark = dataEntity.Post_Remark,
                    SuperiorID = dataEntity.Post_SuperiorID.HasValue? default(int): dataEntity.Post_SuperiorID.Value
                };
            }
            return Position;
        }

        /// <summary>
        /// 数据实体集合List_Repository.Position到业务实体集合List_Model.Entities.Position的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.Position</param>
        /// <returns>业务实体集合List_Model.Entities.Position</returns>
        public static List<Model.Entities.Position> ToModels(this List<Position> entities)
        {
            List<Model.Entities.Position> result = new List<Model.Entities.Position>();
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
        public static Position ToDataEntity(this Model.Entities.Position model)
        {
            Position dataEntity = null;
            if (model != null)
            {
                dataEntity = new Position()
                {
                    Post_ID = model.ID,
                    Post_Name = model.Name,
                    Post_Content = model.Content,
                    Post_Remark = model.Remark,
                    Post_SuperiorID = model.SuperiorID
                };
            }
            return dataEntity;
        }
    }
}
