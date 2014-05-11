using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.ImportantEvent_Center与业务实体Model.Entities.ImportantEvent_Center的映射关系
    /// </summary>
    public static class ImportantEvent_CenterMapping
    {
        /// <summary>
        /// 数据实体Repository.ImportantEvent_Center到业务实体Model.Entities.ImportantEvent_Center的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.ImportantEvent_Center</param>
        /// <returns>业务实体Model.Entities.ImportantEvent_Center</returns>
        public static Model.Entities.ImportantEvent_Center ToModel(this ImportantEvent_Center dataEntity)
        {
            Neusoft.CCS.Model.Entities.ImportantEvent_Center ImportantEvent_Center = null;
            if (dataEntity != null)
            {
                ImportantEvent_Center = new Model.Entities.ImportantEvent_Center()
                {
                    ID = dataEntity.IptEvt_C_ID,
                    Solution = dataEntity.IptEvt_C_Solution,
                    BeginTime = dataEntity.IptEvt_C_BeginDate.HasValue?dataEntity.IptEvt_C_BeginDate.Value:default(DateTime),
                    EndTime = dataEntity.IptEvt_C_EndDate.HasValue?dataEntity.IptEvt_C_EndDate.Value:default(DateTime),
                    Conclusion = dataEntity.IptEvt_C_Conclusion,

                    CaseInfo = dataEntity.CaseInfo.ToModel(),
                    Staff = dataEntity.Staff.ToModel(),
                };
            }
            return ImportantEvent_Center;
        }

        /// <summary>
        /// 数据实体集合List_Repository.ImportantEvent_Center到业务实体集合List_Model.Entities.ImportantEvent_Center的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.ImportantEvent_Center</param>
        /// <returns>业务实体集合List_Model.Entities.ImportantEvent_Center</returns>
        public static List<Model.Entities.ImportantEvent_Center> ToModels(this List<ImportantEvent_Center> entities)
        {
            List<Model.Entities.ImportantEvent_Center> result = new List<Model.Entities.ImportantEvent_Center>();
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
        /// 业务实体Model.Entities.ImportantEvent_Center到数据实体Repository.ImportantEvent_Center的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.ImportantEvent_Center</param>
        /// <returns>数据实体Repository.ImportantEvent_Center</returns>
        public static ImportantEvent_Center ToDataEntity(this Model.Entities.ImportantEvent_Center model)
        {
            ImportantEvent_Center dataEntity = null;
            if (model != null)
            {
                dataEntity = new ImportantEvent_Center()
                {
                    IptEvt_C_ID = model.ID,
                    IptEvt_C_Solution = model.Solution,
                    IptEvt_C_BeginDate = model.BeginTime == default(DateTime) ? default(Nullable<DateTime>) : model.BeginTime,
                    IptEvt_C_EndDate = model.EndTime  == default(DateTime) ? default(Nullable<DateTime>) : model.EndTime,
                    IptEvt_C_Conclusion = model.Conclusion,



                    ID = model.CaseInfo.ID,
                    Stf_ID = model.Staff.ID

                    //CaseInfo = model.CaseInfo.ToDataEntity(),
                    //Staff = model.Staff.ToDataEntity(),
                };
            }
            return dataEntity;
        }
    }
}
