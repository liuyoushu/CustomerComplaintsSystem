using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.CCS.Model.Entities
{
    /// <summary>
    ///  业务
    /// </summary>
    public class Business
    {
        /// <summary>
        /// 业务ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 业务名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 业务描述
        /// </summary>
        public string Describe { get; set; }
    }
}
