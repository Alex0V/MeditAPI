using Medit.DAL.Entities;
using Medit.DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit.DAL.Configurations
{
    public class SessionGroupConfig : IEntityTypeConfiguration<SessionGroup>
    {
        public void Configure(EntityTypeBuilder<SessionGroup> builder)
        {
            builder.HasKey(e => e.Id);


            new SessionGroupSeeding().Seed(builder);
        }
    }
}
