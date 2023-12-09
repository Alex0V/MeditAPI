using Medit.DAL.Entities;
using Medit.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Seeding
{
    public class SessionGroupSeeding : ISeeder<SessionGroup>
    {
        private static readonly List<SessionGroup> sessionGroups = new List<SessionGroup>()
        {
            new SessionGroup()
            {
                Id = 1,
                GroupName = "Mindfulness for Beginners",
                CreationDate = DateTime.Now,
                S3UrlFoto = "foto1"
            },
            new SessionGroup()
            {
                Id = 2,
                GroupName = "Mindfulness Tools",
                CreationDate = DateTime.Now,
                S3UrlFoto = "foto2"
            }
        };

        public void Seed(EntityTypeBuilder<SessionGroup> builder) => builder.HasData(sessionGroups);
    }
}
