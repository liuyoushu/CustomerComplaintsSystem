using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository.Mappings
{
    /// <summary>
    /// 数据实体Repository.ComplaintReturnVisitInfo与业务实体Model.Entities.ComplaintReturnVisitInfo的映射关系
    /// </summary>
    public static class ComplaintReturnVisitInfoMapping
    {
        /// <summary>
        /// 数据实体Repository.ComplaintReturnVisitInfo到业务实体Model.Entities.ComplaintReturnVisitInfo的映射
        /// </summary>
        /// <param name="dataEntity">数据实体Repository.ComplaintReturnVisitInfo</param>
        /// <returns>业务实体Model.Entities.ComplaintReturnVisitInfo</returns>
        public static Model.Entities.ComplaintReturnVisitInfo ToModel(this ComplaintReturnVisitInfo dataEntity)
        {
            Neusoft.CCS.Model.Entities.ComplaintReturnVisitInfo ComplaintReturnVisitInfo = null;
            if (dataEntity != null)
            {
                ComplaintReturnVisitInfo = new Model.Entities.ComplaintReturnVisitInfo()
                {
                    ID = dataEntity.CptReVst_ID,
                    Date = dataEntity.CptReVst_Date.HasValue? dataEntity.CptReVst_Date.Value:default(DateTime),
                    Content = dataEntity.CptReVst_Content,
                    IsSolved = dataEntity.CptReVst_IsSolved.HasValue?dataEntity.CptReVst_IsSolved.Value:default(bool),
                    ComplaintReason = dataEntity.CptReVst_CptReason,
                    BeginTime = dataEntity.CptReVst_BeginTime.HasValue? dataEntity.CptReVst_BeginTime.Value:default(DateTime),
                    EndTime = dataEntity.CptReVst_EndTime.HasValue? dataEntity.CptReVst_EndTime.Value:default(DateTime),

                    CaseInfo = dataEntity.CaseInfo.ToModel(),
                    Staff = dataEntity.Staff.ToModel(),
                };
            }
            return ComplaintReturnVisitInfo;
        }

        /// <summary>
        /// 数据实体集合List_Repository.ComplaintReturnVisitInfo到业务实体集合List_Model.Entities.ComplaintReturnVisitInfo的映射
        /// </summary>
        /// <param name="entities">数据实体集合List_Repository.ComplaintReturnVisitInfo</param>
        /// <returns>业务实体集合List_Model.Entities.ComplaintReturnVisitInfo</returns>
        public static List<Model.Entities.ComplaintReturnVisitInfo> ToModels(this List<ComplaintReturnVisitInfo> entities)
        {
            List<Model.Entities.ComplaintReturnVisitInfo> result = new List<Model.Entities.ComplaintReturnVisitInfo>();
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
        /// 业务实体Model.Entities.ComplaintReturnVisitInfo到数据实体Repository.ComplaintReturnVisitInfo的映射
        /// </summary>
        /// <param name="model">业务实体Model.Entities.ComplaintReturnVisitInfo</param>
        /// <returns>数据实体Repository.ComplaintReturnVisitInfo</returns>
        public static ComplaintReturnVisitInfo ToDataEntity(this Model.Entities.ComplaintReturnVisitInfo model)
        {
            ComplaintReturnVisitInfo dataEntity = null;
            if (model != null)
            {
                dataEntity = new ComplaintReturnVisitInfo()
                {
                    CptReVst_ID = model.ID,
                    CptReVst_Date = model.Date,
                    CptReVst_IsSolved = model.IsSolved,
                    CptReVst_CptReason = model.ComplaintReason,
                    CptReVst_Content = model.Content,
                    CptReVst_BeginTime = model.BeginTime  == default(DateTime) ? default(Nullable<DateTime>) : model.BeginTime,
                    CptReVst_EndTime = model.EndTime  == default(DateTime) ? default(Nullable<DateTime>) : model.EndTime,

                    ID = model.CaseInfo.ID,
                    Stf_ID = model.Staff.ID,
                };
            }
            return dataEntity;
        }
    }
}
