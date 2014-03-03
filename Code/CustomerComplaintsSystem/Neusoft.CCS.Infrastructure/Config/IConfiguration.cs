using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.CCS.Infrastructure.Config
{
    public interface IConfiguration
    {
        string EmailFromAddress { get; }
        string EmailVerifyAddress { get; }
    }
}
