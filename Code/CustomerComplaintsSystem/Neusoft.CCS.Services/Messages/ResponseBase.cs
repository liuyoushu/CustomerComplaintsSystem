using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.Messages
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
