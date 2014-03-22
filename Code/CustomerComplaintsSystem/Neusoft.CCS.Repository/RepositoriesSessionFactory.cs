using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Repositories;
using System.Runtime.Remoting.Messaging;

namespace Neusoft.CCS.Repository
{
    public class RepositoriesSessionFactory : Neusoft.CCS.Model.Repositories.IRepositoriesSessionFactory
    {
        /// <summary>
        /// 此方法的作用： 提高效率，在线程中 共用一个 RepositoriesSession 对象
        /// </summary>
        /// <returns></returns>
        public Model.Repositories.IRepositoriesSession GetRepositoriesSession()
        {
            //从当前线程中 获取 RepositoriesSession 数据仓储会话 对象
            IRepositoriesSession repoSession = CallContext.GetData(typeof(RepositoriesSessionFactory).Name) as RepositoriesSession;

            //Singleton Pattern
            if (repoSession == null)
            {
                repoSession = new RepositoriesSession();
                //以数据仓储会话工厂名作为键、数据仓储会话对象本身为值存储在当前线程中
                CallContext.SetData(typeof(RepositoriesSessionFactory).Name, repoSession);
            }

            return repoSession;
        }
    }
}
