using Neusoft.CCS.Services.ViewModels;
using System.Collections.Generic;

namespace Neusoft.CCS.Services.Messages
{
    public class ComplaintInfoOverviewResponse : ResponseBase
    {
        public List<ComplaintInfoOverviewViewModel> NotArchivedComplaint { get; set; }
    }
}
