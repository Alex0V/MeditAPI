using Medit.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Medit.DAL.Configurations
{
    public class CompletedSessionConfig : IEntityTypeConfiguration<CompletedSession>
    {
        public void Configure(EntityTypeBuilder<CompletedSession> builder)
        {
            builder.HasKey(sc => new { sc.UserId, sc.SessionId });


            builder.HasOne(x => x.User)
                .WithMany(x => x.СompletedSessions)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Sessions)
                .WithMany(x => x.CompletedSessions)
                .HasForeignKey(x => x.SessionId);
        }
    }
}
