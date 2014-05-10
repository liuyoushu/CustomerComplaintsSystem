using System;
using System.Linq;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using System.Data.Entity.Infrastructure;
using Neusoft.CCS.Infrastructure.Logging;

namespace Neusoft.CCS.Repository
{
    public class CaseInfoRepository:ICaseInfoRepository
    {
        private ILogger _logger;

        public CaseInfoRepository()
        {
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }



        public bool Update(Model.Entities.CaseInfo caseInfo)
        {
            //0.0 创建修改的 数据实体对象
            var model = caseInfo.ToDataEntity();
            try
            {
                using (NeusoftCCSEntities context = new NeusoftCCSEntities())
                {
                    //为修改关闭 EF 验证（不然会根据配置文件中EF对象的Nullable属性进行验证）
                    context.Configuration.ValidateOnSaveEnabled = false;
                    //0.1添加到EF管理容器中，并获取 实体对象 的伪包装类对象
                    DbEntityEntry entry = context.Entry<CaseInfo>(model);
                    //**如果使用 Entry 附加 实体对象到数据容器中，则需要手动 设置 实体包装类的对象 的 状态为 Unchanged**
                    //**如果使用 Attach 就不需要这句
                    entry.State = System.Data.EntityState.Unchanged;

                    //0.2标识 实体对象 某些属性 已经被修改了
                    entry.Property("ArchiveDate").IsModified = true;
                    entry.Property("State").IsModified = true;
                    entry.Property("UnsatisfiedWithSolution").IsModified = true;
                    entry.Property("ImptEvtWaitHandledCounter").IsModified = true;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(this, "CaseInfo Update Error", ex);
                return false;
            }

            return true;
        }

        public Model.Entities.CaseInfo RetrieveById(int id)
        {
            Model.Entities.CaseInfo result = new Model.Entities.CaseInfo();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entity = (from caseInfo in context.CaseInfoes
                              where caseInfo.ID == id
                              select caseInfo);
                result = entity.FirstOrDefault().ToModel();
            }
            return result;
        }
    }
}
