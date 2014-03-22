using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Repositories
{
    /// <summary>
    /// 数据访问的便捷接口，相当于外观接口<para />
    /// 里面包含所有的 数据层 接口访问 方式
    /// </summary>
    public partial interface IRepositoriesSession
    {
        int SaveChanges();
    }
}
