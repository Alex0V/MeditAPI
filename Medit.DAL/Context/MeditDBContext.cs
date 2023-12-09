using Medit.DAL.Configurations;
using Medit.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medit.DAL.Context
{
    public class MeditDBContext : DbContext
    {
        public MeditDBContext(DbContextOptions<MeditDBContext> options) : base(options)
        {
        }
        public DbSet<CompletedSession> CompletedSessions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionGroup> SessionGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new SessionConfig());
            modelBuilder.ApplyConfiguration(new SessionGroupConfig());
            modelBuilder.ApplyConfiguration(new CompletedSessionConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
