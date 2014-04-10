using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.CaseInfo与业务实体Model.Entities.CaseInfo的映射关系
    /// </summary>
    public static class CaseInfoMapping
    {
        /// <summary>
        /// 数据实体Repository.CaseInfo到业务实体Model.Entities.CaseInfo的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.CaseInfo</param>
        /// <returns>业务实体Model.Entities.CaseInfo</returns>
        public static Model.Entities.CaseInfo ToModel(this CaseInfo dataEntity)
        {
            Neusoft.CCS.Model.Entities.CaseInfo caseInfo = null;
            if (dataEntity != null)
            {
                caseInfo = new Model.Entities.CaseInfo()
                {
                    ID = dataEntity.ID,
                    ArchiveDate = dataEntity.ArchiveDate.HasValue?dataEntity.ArchiveDate.Value:default(DateTime),
                    State = (CaseState)dataEntity.State,

                    Complainer = dataEntity.Complainer.ToModel(),
                };
            }
            return caseInfo;
        }

        /// <summary>
        /// 数据实体集合List_Repository.CaseInfo到业务实体集合List_Model.Entities.CaseInfo的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.CaseInfo</param>
        /// <returns>业务实体集合List_Model.Entities.CaseInfo</returns>
        public static List<Model.Entities.CaseInfo> ToModels(this List<CaseInfo> entities)
        {
            List<Model.Entities.CaseInfo> result = new List<Model.Entities.CaseInfo>();
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
        /// 业务实体Model.Entities.CaseInfo到数据实体Repository.CaseInfo的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.CaseInfo</param>
        /// <returns>数据实体Repository.CaseInfo</returns>
        public static CaseInfo ToDataEntity(this Model.Entities.CaseInfo model)
        {
            CaseInfo dataEntity = null;
            if (model != null)
            {
                dataEntity = new CaseInfo()
                {
                    ID = model.ID,
                    ArchiveDate = model.ArchiveDate,
                    State = (int)model.State
                };
            }
            return dataEntity;
        }
    }
}
