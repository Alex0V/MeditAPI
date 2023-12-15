using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.DTO.Responses.CompletedSession
{
    public class RecordsByTimeIntervalRespons
    {
        public DateTime CompletedDateTime { get; set; }
        public string Meditation { get; set; }
        public string SessionName { get; set; }
    }
}
