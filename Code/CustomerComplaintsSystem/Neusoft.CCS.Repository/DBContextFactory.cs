using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Repositories;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Neusoft.CCS.Repository
{
    public class DBContextFactory : IDBContextFactory
    {
        #region 创建 EF上下文 对象，在线程中共享 一个 上下文对象 + DbContext GetDbContext()
        /// <summary>
        /// 创建 EF上下文 对象，在线程中共享 一个 上下文对象
        /// </summary>
        /// <returns>EntityFramework上下文对象</returns>
        public System.Data.Entity.DbContext GetDbContext()
        {
            //从当前线程中获取EF上下文对象
            DbContext dbContext = CallContext.GetData(typeof(DBContextFactory).Name) as DbContext;
            if (dbContext == null)
            {
                //Singleton Pattern创建唯一EF上下文
                dbContext = new Neusoft.CCS.Repository.NeusoftCCSEntities();
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                //将新创建的EF上下文对象存入当前线程
                CallContext.SetData(typeof(DBContextFactory).Name, dbContext);
            }
            return dbContext;
        }
        #endregion
    }
}
