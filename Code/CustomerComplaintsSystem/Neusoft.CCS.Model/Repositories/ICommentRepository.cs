using Neusoft.CCS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Model.Repositories
{
    public interface ICommentRepository
    {
        int SaveComment(string ID, string Comment);
        bool IsCommented(string ID);
        List<ComplaintInfo> GetCommentedCases();
    }
}
