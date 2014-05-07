using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.ImportantEvent_Department与业务实体Model.Entities.ImportantEvent_Department的映射关系
    /// </summary>
    public static class ImportantEvent_DepartmentMapping
    {
        /// <summary>
        /// 数据实体Repository.ImportantEvent_Department到业务实体Model.Entities.ImportantEvent_Department的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.ImportantEvent_Department</param>
        /// <returns>业务实体Model.Entities.ImportantEvent_Department</returns>
        public static Model.Entities.ImportantEvent_Department ToModel(this ImportantEvent_Department dataEntity)
        {
            Neusoft.CCS.Model.Entities.ImportantEvent_Department ImportantEvent_Department = null;
            if (dataEntity != null)
            {
                ImportantEvent_Department = new Model.Entities.ImportantEvent_Department()
                {
                    ID = dataEntity.IptEvt_D_ID,
                    Duty = dataEntity.IptEvt_D_Duty,
                    Conclusion = dataEntity.IptEvt_D_Conclusion,
                    BeginTime = dataEntity.IptEvt_D_BeginTime.HasValue?dataEntity.IptEvt_D_BeginTime.Value:default(DateTime),
                    EndTime = dataEntity.IptEvt_D_EndTime.HasValue?dataEntity.IptEvt_D_EndTime.Value:default(DateTime),

                    ImportantEvent_Center = dataEntity.ImportantEvent_Center.ToModel(),
                    CaseInfo = dataEntity.CaseInfo.ToModel(),
                    Staff = dataEntity.Staff.ToModel(),
                };
            }
            return ImportantEvent_Department;
        }

        /// <summary>
        /// 数据实体集合List_Repository.ImportantEvent_Department到业务实体集合List_Model.Entities.ImportantEvent_Department的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.ImportantEvent_Department</param>
        /// <returns>业务实体集合List_Model.Entities.ImportantEvent_Department</returns>
        public static List<Model.Entities.ImportantEvent_Department> ToModels(this List<ImportantEvent_Department> entities)
        {
            List<Model.Entities.ImportantEvent_Department> result = new List<Model.Entities.ImportantEvent_Department>();
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
        /// 业务实体Model.Entities.ImportantEvent_Department到数据实体Repository.ImportantEvent_Department的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.ImportantEvent_Department</param>
        /// <returns>数据实体Repository.ImportantEvent_Department</returns>
        public static ImportantEvent_Department ToDataEntity(this Model.Entities.ImportantEvent_Department model)
        {
            ImportantEvent_Department dataEntity = null;
            if (model != null)
            {
                dataEntity = new ImportantEvent_Department()
                {
                    IptEvt_D_ID = model.ID,
                    IptEvt_D_Duty = model.Duty,
                    IptEvt_D_Conclusion = model.Conclusion,
                    IptEvt_D_BeginTime = model.BeginTime  == default(DateTime) ? default(Nullable<DateTime>) : model.BeginTime,
                    IptEvt_D_EndTime = model.EndTime == default(DateTime) ? default(Nullable<DateTime>) : model.EndTime,
                    IptEvt_C_ID = model.ImportantEvent_Center.ID,
                    Stf_ID = model.Staff.ID,
                    ID = model.CaseInfo.ID
                };
            }
            return dataEntity;
        }
    }
}
