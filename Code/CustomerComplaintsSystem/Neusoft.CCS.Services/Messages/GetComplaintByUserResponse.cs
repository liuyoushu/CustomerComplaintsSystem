﻿using Neusoft.CCS.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.Messages
{
    public class GetComplaintByUserResponse : ResponseBase
    {
        public List<RetrieveComplaintInfoByUserViewModel> ComplaintOverView { get; set; }
    }
}
