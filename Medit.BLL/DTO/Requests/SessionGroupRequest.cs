using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.DTO.Requests
{
    public class SessionGroupRequest
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public string? S3UrlFoto { get; set; }
    }
}
