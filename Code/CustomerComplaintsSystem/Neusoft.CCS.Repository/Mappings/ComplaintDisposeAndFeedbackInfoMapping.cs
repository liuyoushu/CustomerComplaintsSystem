using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.ComplaintDisposeAndFeedbackInfo与业务实体Model.Entities.ComplaintDisposeAndFeedbackInfo的映射关系
    /// </summary>
    public static class ComplaintDisposeAndFeedbackInfoMapping
    {
        /// <summary>
        /// 数据实体Repository.ComplaintDisposeAndFeedbackInfo到业务实体Model.Entities.ComplaintDisposeAndFeedbackInfo的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.ComplaintDisposeAndFeedbackInfo</param>
        /// <returns>业务实体Model.Entities.ComplaintDisposeAndFeedbackInfo</returns>
        public static Model.Entities.ComplaintDisposeAndFeedbackInfo ToModel(this ComplaintDisposeAndFeedbackInfo dataEntity)
        {
            Neusoft.CCS.Model.Entities.ComplaintDisposeAndFeedbackInfo ComplaintDisposeAndFeedbackInfo = null;
            if (dataEntity != null)
            {
                ComplaintDisposeAndFeedbackInfo = new Model.Entities.ComplaintDisposeAndFeedbackInfo()
                {
                    ID = dataEntity.CptDF_ID,
                    Solution = dataEntity.CptDF_Solution,
                    Content = dataEntity.CptDF_Content,
                    Satisfaction = dataEntity.CptDF_Satisfaction.HasValue?(Model.Entities.Satisfaction)dataEntity.CptDF_Satisfaction:default(Model.Entities.Satisfaction),
                    BeginTime = dataEntity.CptDF_BeginTime.HasValue? dataEntity.CptDF_BeginTime.Value:default(DateTime),
                    EndTime = dataEntity.CptDF_EndTime.HasValue? dataEntity.CptDF_EndTime.Value:default(DateTime),

                    CaseInfo = dataEntity.CaseInfo.ToModel(),
                    Staff = dataEntity.Staff.ToModel(),
                    
                };
            }
            return ComplaintDisposeAndFeedbackInfo;
        }

        /// <summary>
        /// 数据实体集合List_Repository.ComplaintDisposeAndFeedbackInfo到业务实体集合List_Model.Entities.ComplaintDisposeAndFeedbackInfo的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.ComplaintDisposeAndFeedbackInfo</param>
        /// <returns>业务实体集合List_Model.Entities.ComplaintDisposeAndFeedbackInfo</returns>
        public static List<Model.Entities.ComplaintDisposeAndFeedbackInfo> ToModels(this List<ComplaintDisposeAndFeedbackInfo> entities)
        {
            List<Model.Entities.ComplaintDisposeAndFeedbackInfo> result = new List<Model.Entities.ComplaintDisposeAndFeedbackInfo>();
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
        /// 业务实体Model.Entities.ComplaintDisposeAndFeedbackInfo到数据实体Repository.ComplaintDisposeAndFeedbackInfo的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.ComplaintDisposeAndFeedbackInfo</param>
        /// <returns>数据实体Repository.ComplaintDisposeAndFeedbackInfo</returns>
        public static ComplaintDisposeAndFeedbackInfo ToDataEntity(this Model.Entities.ComplaintDisposeAndFeedbackInfo model)
        {
            ComplaintDisposeAndFeedbackInfo dataEntity = null;
            if (model != null)
            {
                dataEntity = new ComplaintDisposeAndFeedbackInfo()
                {
                   CptDF_ID = model.ID,
                   CptDF_Solution = model.Solution,
                   CptDF_Content = model.Content,
                   CptDF_Satisfaction = (int)model.Satisfaction,
                   CptDF_BeginTime = model.BeginTime == default(DateTime) ? default(Nullable<DateTime>) : model.BeginTime,
                   CptDF_EndTime = model.EndTime == default(DateTime) ? default(Nullable<DateTime>) : model.EndTime,

                   ID = model.CaseInfo.ID,
                   Stf_ID = model.Staff.ID,
                };
            }
            return dataEntity;
        }
    }
}

