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
    public class SessionSeeding : ISeeder<Session>
    {
        private static readonly List<Session> sessions = new List<Session>()
        {
            new Session()
            {
                Id = 1,
                SessionGroupId = 1,
                SessionName = "The Big Idea",
            },
            new Session()
            {
                Id = 2,
                SessionGroupId = 1,
                SessionName = "Homebase",
            },
            new Session()
            {
                Id = 3,
                SessionGroupId = 1,
                SessionName = "Pop Out of Your Thoughts"
            },
            new Session()
            {
                Id = 4,
                SessionGroupId = 1,
                SessionName = "Inner Smoothness"
            },
            new Session()
            {
                Id = 5,
                SessionGroupId = 1,
                SessionName = "Take the Power Back"
            },
            new Session()
            {
                Id = 6,
                SessionGroupId = 2,
                SessionName = "Introduction"
            },
            new Session()
            {
                Id = 7,
                SessionGroupId = 2,
                SessionName = "Dealing with Change and Uncertainty"
            },
            new Session()
            {
                Id = 8,
                SessionGroupId = 2,
                SessionName = "Combating Loneliness"
            },
            new Session()
            {
                Id = 9,
                SessionGroupId = 2,
                SessionName = "Getting Through a Hectic Day"
            },
            new Session()
            {
                Id = 10,
                SessionGroupId = 2,
                SessionName = "Dealing with Negativity in the World"
            },
            new Session()
            {
                Id = 11,
                SessionGroupId = 2,
                SessionName = "Easing Holiday Stress"
            },

        };

        public void Seed(EntityTypeBuilder<Session> builder) => builder.HasData(sessions);
    }
}
