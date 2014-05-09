﻿using Neusoft.CCS.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.Interfaces
{
    public interface IImptEvtDeptService
    {
        LoadingImptEventBoxForDeptResponse LoadingImptEventBoxForDept();

        LoadingImptEvtDeptFormResponse LoadingImptEvtDeptForm(int id);
    }
}
