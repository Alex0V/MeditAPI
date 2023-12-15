using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.DTO.Requests.CompletedSession
{
    public class AddCompletedSessionRequest
    {
        public int SessionId { get; set; }
        public string UserName { get; set; }
    }
}
