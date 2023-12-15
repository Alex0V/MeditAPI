using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.DTO.Requests.CompletedSession
{
    public class RecordsByTimeIntervalRequest
    {
        public string UserName { get; set; }
        public string Period { get; set; }
    }
}
