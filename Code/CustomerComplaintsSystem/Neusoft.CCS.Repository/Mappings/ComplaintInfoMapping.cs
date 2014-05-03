using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.ComplaintInfo与业务实体Model.Entities.ComplaintInfo的映射关系
    /// </summary>
    public static class ComplaintInfoMapping
    {
        /// <summary>
        /// 数据实体Repository.ComplaintInfo到业务实体Model.Entities.ComplaintInfo的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.ComplaintInfo</param>
        /// <returns>业务实体Model.Entities.ComplaintInfo</returns>
        public static Model.Entities.ComplaintInfo ToModel(this ComplaintInfo dataEntity)
        {
            Neusoft.CCS.Model.Entities.ComplaintInfo ComplaintInfo = null;
            if (dataEntity != null)
            {
                ComplaintInfo = new Model.Entities.ComplaintInfo()
                {
                    ID = dataEntity.ID,
                    Way = dataEntity.Cpt_Way,
                    Date = dataEntity.Cpt_Date,
                    Area = dataEntity.Cpt_Area,
                    Class = dataEntity.Cpt_Class,
                    Describe = dataEntity.Cpt_Describe,
                    BeginTime = dataEntity.Cpt_BeginTime.HasValue ? dataEntity.Cpt_BeginTime.Value : default(DateTime),
                    EndTime = dataEntity.Cpt_EndTime.HasValue ? dataEntity.Cpt_EndTime.Value : default(DateTime),

                    CaseInfo = dataEntity.CaseInfo.ToModel(),
                    Business = dataEntity.Business.ToModel(),
                };
            }
            return ComplaintInfo;
        }

        /// <summary>
        /// 数据实体集合List_Repository.ComplaintInfo到业务实体集合List_Model.Entities.ComplaintInfo的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.ComplaintInfo</param>
        /// <returns>业务实体集合List_Model.Entities.ComplaintInfo</returns>
        public static List<Model.Entities.ComplaintInfo> ToModels(this List<ComplaintInfo> entities)
        {
            List<Model.Entities.ComplaintInfo> result = new List<Model.Entities.ComplaintInfo>();
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
        /// 业务实体Model.Entities.ComplaintInfo到数据实体Repository.ComplaintInfo的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.ComplaintInfo</param>
        /// <returns>数据实体Repository.ComplaintInfo</returns>
        public static ComplaintInfo ToDataEntity(this Model.Entities.ComplaintInfo model)
        {
            ComplaintInfo dataEntity = null;
            if (model != null)
            {
                dataEntity = new ComplaintInfo()
                {
                    ID = model.ID,
                    Cpt_Way = model.Way,
                    Cpt_Date = model.Date,
                    Cpt_Area = model.Area,
                    Cpt_Class = model.Class,
                    Cpt_Describe = model.Describe,
                    Cpt_BeginTime = model.BeginTime  == default(DateTime) ? default(Nullable<DateTime>) : model.BeginTime,
                    Cpt_EndTime = model.EndTime == default(DateTime) ? default(Nullable<DateTime>) : model.EndTime,
                };
            }
            return dataEntity;
        }
    }
}
