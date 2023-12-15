using Medit.DAL.Entities.Base;

namespace Medit.DAL.Entities
{
    public class Meditation : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string FotoKey { get; set; }
        public string? S3UrlFoto { get; set; }
        public string? Duration { get; set; }

        public List<Session> Sessions { get; set; } = new();
    }
}
