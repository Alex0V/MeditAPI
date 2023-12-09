using Medit.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Entities
{
    public class Session : Entity
    {
        public int SessionGroupId { get; set; }
        public SessionGroup? SessionGroup { get; set; }
        public string? SessionName { get; set; }
        public string? S3UrlAudio { get; set; }
        public string? Duration { get; set; }

        public List<CompletedSession> CompletedSessions { get; set; } = new();
    }
}
