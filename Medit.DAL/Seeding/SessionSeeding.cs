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
                MeditationId = 1,
                SessionName = "Dreamy Breeze",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Dreamy+Breeze.mp3",
                AudioKey = "Dreamy Breeze.mp3"
            },
            new Session()
            {
                Id = 2,
                MeditationId = 1,
                SessionName = "Peace of the Lake",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Peace+of+the+Lake.mp3",
                AudioKey = "Peace of the Lake.mp3"
            },
            new Session()
            {
                Id = 3,
                MeditationId = 1,
                SessionName = "Silent Symphony",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Silent+Symphony.mp3",
                AudioKey = "Silent Symphony.mp3"
            },
            new Session()
            {
                Id = 4,
                MeditationId = 1,
                SessionName = "Calm Waters",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Calm+Waters.mp3",
                AudioKey = "Calm Waters.mp3"
            },
            new Session()
            {
                Id = 5,
                MeditationId = 1,
                SessionName = "Deep Equilibrium",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Deep+Equilibrium.mp3",
                AudioKey = "Deep Equilibrium.mp3"
            },
            new Session()
            {
                Id = 6,
                MeditationId = 2,
                SessionName = "Transcendental Tranquility",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Transcendental+Tranquility.mp3",
                AudioKey = "Transcendental Tranquility.mp3"
            },
            new Session()
            {
                Id = 7,
                MeditationId = 2,
                SessionName = "Path to Inner Peace",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Path+to+Inner+Peace.mp3",
                AudioKey = "Path to Inner Peace.mp3"
            },
            new Session()
            {
                Id = 8,
                MeditationId = 2,
                SessionName = "Conscious Immersion",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Conscious+Immersion.mp3",
                AudioKey = "Conscious Immersion.mp3"
            },
            new Session()
            {
                Id = 9,
                MeditationId = 3,
                SessionName = "Kindness Unfolding Practice",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Kindness+Unfolding+Practice.mp3",
                AudioKey = "Kindness Unfolding Practice.mp3"
            },
            new Session()
            {
                Id = 10,
                MeditationId = 3,
                SessionName = "Radiant Love Meditation",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Radiant+Love+Meditation.mp3",
                AudioKey = "Radiant Love Meditation.mp3"
            },
            new Session()
            {
                Id = 11,
                MeditationId = 3,
                SessionName = "Meditation of Compassionate Hearts",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Meditation+of+Compassionate+Hearts.mp3",
                AudioKey = "Meditation of Compassionate Hearts.mp3"
            },
            new Session()
            {
                Id = 12,
                MeditationId = 4,
                SessionName = "Mindful Body Unveiling",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Mindful+Body+Unveiling.mp3",
                AudioKey = "Mindful Body Unveiling.mp3"
            },
            new Session()
            {
                Id = 13,
                MeditationId = 4,
                SessionName = "Somatic Awareness Practice",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Somatic+Awareness+Practice.mp3",
                AudioKey = "Somatic Awareness Practice.mp3"
            },
            new Session()
            {
                Id = 14,
                MeditationId = 4,
                SessionName = "Sensory Body Exploration",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Sensory+Body+Exploration.mp3",
                AudioKey = "Sensory Body Exploration.mp3"
            },
            new Session()
            {
                Id = 15,
                MeditationId = 5,
                SessionName = "Insightful Mindfulness Practice",
                S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Insightful+Mindfulness+Practice.mp3",
                AudioKey = "Insightful Mindfulness Practice.mp3"
            }

        };

        public void Seed(EntityTypeBuilder<Session> builder) => builder.HasData(sessions);
    }
}
