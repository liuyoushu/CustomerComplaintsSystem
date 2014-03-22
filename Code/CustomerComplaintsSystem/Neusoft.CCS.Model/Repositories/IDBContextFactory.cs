using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Neusoft.CCS.Model.Repositories
{
    /// <summary>
    /// EF数据上下文工厂
    /// </summary>
    /// <!--数据层父类BaseRepository需要访问EF数据上下文，但是 该数据上下文可能会换，故也用工厂封装创建。
    /// 主要目的还是 在线程中共享同一个上下文对象，以达到同一个Action多次操作访问一个DBContext最后再一次性SaveChanges()的目的-->
    public interface IDBContextFactory
    {
        /// <summary>
        /// 获取EF上下文对象
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}
