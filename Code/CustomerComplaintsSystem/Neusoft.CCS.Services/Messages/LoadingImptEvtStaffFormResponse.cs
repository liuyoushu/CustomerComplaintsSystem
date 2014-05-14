using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Services.ViewModels;

namespace Neusoft.CCS.Services.Messages
{
    public class LoadingImptEvtStaffFormResponse : ResponseBase
    {
        public ImptEvtStaffFormViewModel ImptEvtStaffForm { get; set; }
    }
}
