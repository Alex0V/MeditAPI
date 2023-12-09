using Medit.DAL.Entities.Base;

namespace Medit.DAL.Entities
{
    public class CompletedSession : Entity
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int SessionId { get; set; }
        public Session? Sessions { get; set; }

        public int SessionСounter { get; set; }
    }
}
