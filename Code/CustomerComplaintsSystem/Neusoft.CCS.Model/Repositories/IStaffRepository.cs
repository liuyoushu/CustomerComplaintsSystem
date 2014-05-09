using Neusoft.CCS.Model.Entities;
using System.Collections.Generic;

namespace Neusoft.CCS.Model.Repositories
{
    public interface IStaffRepository
    {
        Staff RetrieveById(string id);
        Dictionary<string, string> RetrieveListWithChargingBizName();
        Dictionary<string, string> RetrieveListBySuperiorPositionId(int positionId);
    }
}
