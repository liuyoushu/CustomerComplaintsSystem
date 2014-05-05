using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;

namespace Neusoft.CCS.Services.Interfaces
{
    public interface IImptEvtCenterService
    {
        LoadingImptEventBoxForCenterResponse LoadingImptEventBoxForCenter();

        LoadingImptEvtCenterFormResponse LoadingImptEvtCenterForm(int id);

        bool SubmitImptEvtCenterForm(ImptEvtCenterFormViewModel imptEvtCenterForm);
    }
}
