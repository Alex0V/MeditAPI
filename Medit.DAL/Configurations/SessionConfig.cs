using Medit.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Medit.DAL.Seeding;

namespace Medit.DAL.Configurations
{
    public class SessionConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.HasOne(x => x.Meditation)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.MeditationId)
                .OnDelete(DeleteBehavior.Cascade);

            new SessionSeeding().Seed(builder);
        }
    }
}
