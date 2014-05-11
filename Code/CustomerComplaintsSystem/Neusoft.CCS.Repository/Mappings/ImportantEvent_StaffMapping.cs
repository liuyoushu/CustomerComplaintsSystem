using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.ImportantEvent_Staff与业务实体Model.Entities.ImportantEvent_Staff的映射关系
    /// </summary>
    public static class ImportantEvent_StaffMapping
    {
        /// <summary>
        /// 数据实体Repository.ImportantEvent_Staff到业务实体Model.Entities.ImportantEvent_Staff的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.ImportantEvent_Staff</param>
        /// <returns>业务实体Model.Entities.ImportantEvent_Staff</returns>
        public static Model.Entities.ImportantEvent_Staff ToModel(this ImportantEvent_Staff dataEntity)
        {
            Neusoft.CCS.Model.Entities.ImportantEvent_Staff ImportantEvent_Staff = null;
            if (dataEntity != null)
            {
                ImportantEvent_Staff = new Model.Entities.ImportantEvent_Staff()
                {
                    ID = dataEntity.IptEvt_S_ID,
                    Content = dataEntity.IptEvt_S_Content,
                    BeginTime = dataEntity.IptEvt_S_BeginTime.HasValue?dataEntity.IptEvt_S_BeginTime.Value:default(DateTime),
                    EndTime = dataEntity.IptEvt_S_EndTime.HasValue?dataEntity.IptEvt_S_EndTime.Value:default(DateTime),

                    ImportantEvent_Department = dataEntity.ImportantEvent_Department.ToModel(),
                    CaseInfo = dataEntity.CaseInfo.ToModel(),
                    Staff = dataEntity.Staff.ToModel(),
                };
            }
            return ImportantEvent_Staff;
        }

        /// <summary>
        /// 数据实体集合List_Repository.ImportantEvent_Staff到业务实体集合List_Model.Entities.ImportantEvent_Staff的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.ImportantEvent_Staff</param>
        /// <returns>业务实体集合List_Model.Entities.ImportantEvent_Staff</returns>
        public static List<Model.Entities.ImportantEvent_Staff> ToModels(this List<ImportantEvent_Staff> entities)
        {
            List<Model.Entities.ImportantEvent_Staff> result = new List<Model.Entities.ImportantEvent_Staff>();
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
        /// 业务实体Model.Entities.ImportantEvent_Staff到数据实体Repository.ImportantEvent_Staff的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.ImportantEvent_Staff</param>
        /// <returns>数据实体Repository.ImportantEvent_Staff</returns>
        public static ImportantEvent_Staff ToDataEntity(this Model.Entities.ImportantEvent_Staff model)
        {
            ImportantEvent_Staff dataEntity = null;
            if (model != null)
            {
                dataEntity = new ImportantEvent_Staff()
                {
                    IptEvt_S_ID = model.ID,
                    IptEvt_S_Content = model.Content,
                    IptEvt_S_BeginTime = model.BeginTime == default(DateTime) ? default(Nullable<DateTime>) : model.BeginTime,
                    IptEvt_S_EndTime = model.EndTime == default(DateTime) ? default(Nullable<DateTime>) : model.EndTime,

                   //CaseInfo = model.CaseInfo.ToDataEntity(),
                   //ImportantEvent_Department = model.ImportantEvent_Department.ToDataEntity(),
                   //Staff = model.Staff.ToDataEntity(),
                   ID = model.CaseInfo.ID,
                   IptEvt_D_ID = model.ImportantEvent_Department.ID,
                   Stf_ID = model.Staff.ID,
                    
                };
            }
            return dataEntity;
        }
    }
}
