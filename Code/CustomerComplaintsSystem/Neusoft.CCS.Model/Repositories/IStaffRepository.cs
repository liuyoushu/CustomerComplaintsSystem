using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IStaffRepository
    {
        Staff RetrieveById(string id);
    }
}
