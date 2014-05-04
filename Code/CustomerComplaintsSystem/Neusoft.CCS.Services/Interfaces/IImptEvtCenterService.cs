using Neusoft.CCS.Services.Messages;

namespace Neusoft.CCS.Services.Interfaces
{
    public interface IImptEvtCenterService
    {
        LoadingImptEventBoxForCenterResponse LoadingImptEventBoxForCenter();

        LoadingImptEvtCenterFormResponse LoadingImptEvtCenterForm(int id);
    }
}
