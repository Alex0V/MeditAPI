using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.DTO.Responses
{
    public class SessionGroupResponse
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public string? S3UrlFoto { get; set; }
    }
}
