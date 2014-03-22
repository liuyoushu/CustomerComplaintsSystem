using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Repositories
{
    /// <summary>
    /// 数据仓储会话工厂
    /// </summary>
    public interface IRepositoriesSessionFactory
    {
        IRepositoriesSession GetRepositoriesSession();
    }
}
