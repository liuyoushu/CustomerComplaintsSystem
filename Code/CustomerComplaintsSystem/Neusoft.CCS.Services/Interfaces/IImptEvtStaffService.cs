﻿using Neusoft.CCS.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.Interfaces
{
    public interface IImptEvtStaffService
    {
        LoadingImptEventBoxForStaffResponse LoadingImptEventBoxForStaff();//string staffId

        LoadingImptEvtStaffFormResponse LoadingImptEvtStaffForm(int id);

        bool ImptEvtHandled(ViewModels.ImptEvtStaffFormViewModel imptEvtStaffFormViewModel);
    }
}
