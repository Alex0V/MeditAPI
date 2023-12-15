using Medit.DAL.Entities.Base;

namespace Medit.DAL.Entities
{
    public class Session : Entity
    {
        public int MeditationId { get; set; }
        public Meditation? Meditation { get; set; }
        public string? SessionName { get; set; }
        public string? S3UrlAudio { get; set; }
        public string? AudioKey { get; set; }

        public List<CompletedSession> CompletedSessions { get; set; } = new();
    }
}
