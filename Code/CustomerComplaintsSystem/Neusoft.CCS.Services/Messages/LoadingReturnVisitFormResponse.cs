using Neusoft.CCS.Services.ViewModels;

namespace Neusoft.CCS.Services.Messages
{
    public class LoadingReturnVisitFormResponse : ResponseBase
    {
        public ReturnVisitFormViewModel ReturnVisitForm { get; set; }
    }
}
