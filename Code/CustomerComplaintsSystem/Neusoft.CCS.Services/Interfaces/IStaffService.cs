using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;

namespace Neusoft.CCS.Services.Interfaces
{
    public interface IStaffService
    {
        LoginedStaffViewModel Login(LoginedStaffViewModel loginedStaff);
    }
}
