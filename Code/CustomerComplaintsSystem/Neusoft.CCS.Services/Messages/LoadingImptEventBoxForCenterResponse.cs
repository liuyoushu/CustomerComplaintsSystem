using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;
using System.Collections.Generic;

namespace Neusoft.CCS.Services.Messages
{
    public class LoadingImptEventBoxForCenterResponse : ResponseBase
    {
        public Dictionary<int, ComplaintInfoOverviewViewModel> ImptEventBoxForCenter { get; set; }
    }
}
