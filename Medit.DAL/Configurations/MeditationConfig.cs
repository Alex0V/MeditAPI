using Medit.DAL.Entities;
using Medit.DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit.DAL.Configurations
{
    public class MeditationConfig : IEntityTypeConfiguration<Meditation>
    {
        public void Configure(EntityTypeBuilder<Meditation> builder)
        {
            builder.HasKey(e => e.Id);


            new MeditationSeeding().Seed(builder);
        }
    }
}
