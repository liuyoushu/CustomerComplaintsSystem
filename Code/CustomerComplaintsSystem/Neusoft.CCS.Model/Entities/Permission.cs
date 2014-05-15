using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.CCS.Model.Entities
{
    public class Permission
    {
        public int PermissionId { get; set; }

        public string PermissionDisplayName { get; set; }

        public string PermissionActionName { get; set; }

        public string PermissionControllerName { get; set; }

        public string PermissionCategory { get; set; }
    }
}
