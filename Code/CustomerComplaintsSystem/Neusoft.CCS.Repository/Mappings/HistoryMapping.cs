using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.History与业务实体Model.Entities.History的映射关系
    /// </summary>
    public static class HistoryMapping
    {
        /// <summary>
        /// 数据实体Repository.History到业务实体Model.Entities.History的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.History</param>
        /// <returns>业务实体Model.Entities.History</returns>
        public static Model.Entities.History ToModel(this History dataEntity)
        {
            Neusoft.CCS.Model.Entities.History History = null;
            if (dataEntity != null)
            {
                History = new Model.Entities.History()
                {
                    ID = dataEntity.History_ID,
                    Process = dataEntity.History_Process,
                    HandleTime = dataEntity.History_HandleTime,
                 
                    CaseInfo = dataEntity.CaseInfo.ToModel(),
                    Staff = dataEntity.Staff.ToModel(),
                };
            }
            return History;
        }

        /// <summary>
        /// 数据实体集合List_Repository.History到业务实体集合List_Model.Entities.History的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.History</param>
        /// <returns>业务实体集合List_Model.Entities.History</returns>
        public static List<Model.Entities.History> ToModels(this List<History> entities)
        {
            List<Model.Entities.History> result = new List<Model.Entities.History>();
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
        /// 业务实体Model.Entities.History到数据实体Repository.History的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.History</param>
        /// <returns>数据实体Repository.History</returns>
        public static History ToDataEntity(this Model.Entities.History model)
        {
            History dataEntity = null;
            if (model != null)
            {
                dataEntity = new History()
                {
                    History_ID = model.ID,
                    History_Process = model.Process,
                    History_HandleTime = model.HandleTime,

                    ID = model.CaseInfo.ID,
                    Stf_ID = model.Staff.ID,
                };
            }
            return dataEntity;
        }
    }
}
