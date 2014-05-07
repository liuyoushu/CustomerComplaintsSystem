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
    public class ImptEvtCenterRepository : IImptEvtCenterRepository
    {
        private ILogger _logger;

        public ImptEvtCenterRepository()
        {
            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        public bool Create(Model.Entities.ImportantEvent_Center imptEvtCenter)
        {
            var model = imptEvtCenter.ToDataEntity();
            try
            {
                using (NeusoftCCSEntities context = new NeusoftCCSEntities())
                {
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.ImportantEvent_Center.Add(model);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(this, "ImportantEvent_Center Create Error", ex);
                return false;
            }

            return true;
        }


        public Dictionary<int, Model.Entities.ComplaintInfo> RetrieveList()
        {
            Dictionary<int, Model.Entities.ComplaintInfo> result = new Dictionary<int, Model.Entities.ComplaintInfo>();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var imptEvtCenterList = (from item in context.ImportantEvent_Center
                                         join caseInfo in context.CaseInfoes on item.ID equals caseInfo.ID
                                         where (caseInfo.State == ((int)CaseState.ImportantEvent) || 
                                                caseInfo.State == ((int)CaseState.ImptEvt_Handled))
                                         select item).ToList();
                foreach (var imptEvt in imptEvtCenterList)
                {
                    var cptInfo = (from item in context.ComplaintInfoes
                                   where item.ID == imptEvt.CaseInfo.ID
                                   orderby item.Cpt_EndTime descending
                                   select item).FirstOrDefault().ToModel();
                    result.Add(imptEvt.IptEvt_C_ID, cptInfo);
                }
            }
            return result;
        }



        public Model.Entities.ImportantEvent_Center RetrieveById(int id)
        {
            Model.Entities.ImportantEvent_Center result = new Model.Entities.ImportantEvent_Center();
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var entity = (from item in context.ImportantEvent_Center
                              where item.IptEvt_C_ID == id
                              select item);
                result = entity.FirstOrDefault().ToModel();
            }
            return result;
        }


        public bool Update(Model.Entities.ImportantEvent_Center imptEvtCenter)
        {
            //0.0 创建修改的 数据实体对象
            var model = imptEvtCenter.ToDataEntity();
            try
            {
                using (NeusoftCCSEntities context = new NeusoftCCSEntities())
                {
                    //为修改关闭 EF 验证（不然会根据配置文件中EF对象的Nullable属性进行验证）
                    context.Configuration.ValidateOnSaveEnabled = false;
                    //0.1添加到EF管理容器中，并获取 实体对象 的伪包装类对象
                    DbEntityEntry entry = context.Entry<ImportantEvent_Center>(model);
                    //**如果使用 Entry 附加 实体对象到数据容器中，则需要手动 设置 实体包装类的对象 的 状态为 Unchanged**
                    //**如果使用 Attach 就不需要这句
                    entry.State = System.Data.EntityState.Unchanged;

                    //0.2标识 实体对象 某些属性 已经被修改了
                    entry.Property("IptEvt_C_Solution").IsModified = true;
                    entry.Property("IptEvt_C_BeginDate").IsModified = true;
                    entry.Property("IptEvt_C_EndDate").IsModified = true;
                    entry.Property("IptEvt_C_Conclusion").IsModified = true;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(this, "ImportantEvent_Center Update Error", ex);
                return false;
            }

            return true;
        }
    }
}
