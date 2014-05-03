using System.Collections.Generic;
using Neusoft.CCS.Services.ViewModels;

namespace Neusoft.CCS.Services.Messages
{
    public class LoadingReturnVisitBoxResponse : ResponseBase
    {
        public List<ComplaintInfoOverviewViewModel> RetrunVisitBox { get; set; }
    }
}
