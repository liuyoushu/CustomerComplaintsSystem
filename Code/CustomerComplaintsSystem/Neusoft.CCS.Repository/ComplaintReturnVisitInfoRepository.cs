using System;
using System.Collections.Generic;
using System.Linq;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Infrastructure.Logging;
using System.Data.Entity.Infrastructure;

namespace Neusoft.CCS.Repository
{
    public class ComplaintReturnVisitInfoRepository : IComplaintReturnVisitInfoRepository
    {
        private ILogger _logger;

        public ComplaintReturnVisitInfoRepository()
        {
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        public List<Model.Entities.ComplaintInfo> RetrieveReturnVistingList()
        {
            List<Model.Entities.ComplaintInfo> result = new List<Model.Entities.ComplaintInfo>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entities = (from cpt in context.ComplaintInfoes
                                join caseInfo in context.CaseInfoes on cpt.ID equals caseInfo.ID
                                join cptDAFInfo in context.ComplaintDisposeAndFeedbackInfoes on cpt.ID equals cptDAFInfo.ID
                                join cptRVInfo in context.ComplaintReturnVisitInfoes on cpt.ID equals cptRVInfo.ID
                                where (caseInfo.State == ((int)CaseState.ReturnVisiting)
                                && cptDAFInfo.CptDF_Satisfaction == ((int)Satisfaction.Unsatisfied)
                                || cptDAFInfo.CptDF_Satisfaction == ((int)Satisfaction.Normal))
                                select cpt);
                result = entities.ToList().ToModels();
            }

            return result;
        }


        public Model.Entities.ComplaintReturnVisitInfo RetrieveById(int id)
        {
            Model.Entities.ComplaintReturnVisitInfo result = new Model.Entities.ComplaintReturnVisitInfo();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entity = (from cptRVInfo in context.ComplaintReturnVisitInfoes
                              where cptRVInfo.ID == id
                              select cptRVInfo);
                result = entity.FirstOrDefault().ToModel();
            }
            return result;
        }


        public bool Update(Model.Entities.ComplaintReturnVisitInfo cptRVInfo)
        {
            //0.0 创建修改的 数据实体对象
            var model = cptRVInfo.ToDataEntity();
            try
            {
                using (NeusoftCCSEntities context = new NeusoftCCSEntities())
                {
                    //为修改关闭 EF 验证（不然会根据配置文件中EF对象的Nullable属性进行验证）
                    context.Configuration.ValidateOnSaveEnabled = false;
                    //0.1添加到EF管理容器中，并获取 实体对象 的伪包装类对象
                    DbEntityEntry entry = context.Entry<ComplaintReturnVisitInfo>(model);
                    //**如果使用 Entry 附加 实体对象到数据容器中，则需要手动 设置 实体包装类的对象 的 状态为 Unchanged**
                    //**如果使用 Attach 就不需要这句
                    entry.State = System.Data.EntityState.Unchanged;

                    //0.2标识 实体对象 某些属性 已经被修改了
                    entry.Property("CptReVst_Date").IsModified = true;
                    entry.Property("CptReVst_Content").IsModified = true;
                    entry.Property("CptReVst_IsSolved").IsModified = true;
                    entry.Property("CptReVst_CptReason").IsModified = true;
                    entry.Property("CptReVst_BeginTime").IsModified = true;
                    entry.Property("CptReVst_EndTime").IsModified = true;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(this, "ComplaintReturnVisitInfo Update Error", ex);
                return false;
            }

            return true;
        }
    }
}
