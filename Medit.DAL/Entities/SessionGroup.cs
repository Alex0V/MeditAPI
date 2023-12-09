using Medit.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Entities
{
    public class SessionGroup : Entity
    {
        public string? GroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public string? S3UrlFoto { get; set; }

        public List<Session> Sessions { get; set; } = new();
    }
}
