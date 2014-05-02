using System.Collections.Generic;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IComplaintDisposeAndFeedbackInfoRepository
    {
        ComplaintDisposeAndFeedbackInfo RetrieveById(int id);
    }
}
