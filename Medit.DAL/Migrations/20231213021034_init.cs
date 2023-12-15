using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medit.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meditations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S3UrlFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meditations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordExpiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeditationId = table.Column<int>(type: "int", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S3UrlAudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Meditations_MeditationId",
                        column: x => x.MeditationId,
                        principalTable: "Meditations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    AuditionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedSessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meditations",
                columns: new[] { "Id", "CreationDate", "Description", "Duration", "FotoKey", "Name", "S3UrlFoto" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 13, 4, 10, 33, 39, DateTimeKind.Local).AddTicks(3840), "Focuses on being present in the moment and non-judgmentally observing your thoughts and surroundings.", "10-30 minutes", "mindfulness-meditation.jpg", "Mindfulness Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/mindfulness-meditation.jpg" },
                    { 2, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3613), "Uses a mantra to help quiet the mind and achieve a deep state of relaxation.", "10-30 minutes", "transcendental-meditation.jpg", "Transcendental Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/transcendental-meditation.jpg" },
                    { 3, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3675), "Involves generating feelings of love and compassion towards oneself and others.", "10-30 minutes", "loving-kindness-meditation.jpg", "Loving-Kindness Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/loving-kindness-meditation.jpg" },
                    { 4, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3683), "Involves systematically bringing attention to different parts of the body, noticing sensations and relaxing tension.", "10-30 minutes", "body-scan-meditation.jpg", "Body Scan Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/body-scan-meditation.jpg" },
                    { 5, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3686), "Involves observing the breath and bodily sensations to gain insight into the nature of reality.", "30-60 minutes", "vipassana-meditation.jpg", "Vipassana Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/vipassana-meditation.jpg" },
                    { 6, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3702), "Involves sitting in silence and focusing on the breath, often with the support of a teacher or group.", "20-40 minutes", "zen-meditation.jpg", "Zen Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/zen-meditation.jpg" },
                    { 7, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3706), "Involves focusing on each of the body's energy centers to balance and align them.", "10-30 minutes", "chakra-meditation.jpg", "Chakra Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/chakra-meditation.jpg" },
                    { 8, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3710), "Involves repeating a word or phrase to focus the mind and achieve a calm state.", "10-30 minutes", "mantra-meditation.jpg", "Mantra Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/mantra-meditation.jpg" },
                    { 9, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3714), "Involves counting each breath to maintain focus and concentration.", "10-30 minutes", "breath-counting-meditation.jpg", "Breath Counting Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/breath-counting-meditation.jpg" },
                    { 10, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3720), "Involves walking slowly and mindfully, focusing on each step and the sensations in the body.", "10-30 minutes", "walking-meditation.jpg", "Walking Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/walking-meditation.jpg" },
                    { 11, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3723), "Involves creating a mental image or scenario to promote relaxation and positive emotions.", "10-30 minutes", "visualization-meditation.jpg", "Visualization Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg" },
                    { 12, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3726), "Involves lying down and systematically relaxing different parts of the body to achieve a deep state of relaxation.", "20-40 minutes", "yoga-nidra-meditation.jpg", "Yoga Nidra Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/yoga-nidra-meditation.jpg" },
                    { 13, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3730), "Involves focusing on a particular sound or a series of sounds to promote relaxation.", "10-30 minutes", "sound-meditation.jpg", "Sound Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/sound-meditation.jpg" },
                    { 14, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3734), "Involves combining movement, breath, and visualization to improve physical and mental health.", "10-30 minutes", "qi-gong-meditation.jpg", "Qi Gong Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/qi-gong-meditation.jpg" },
                    { 15, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3737), "Involves combining breathwork, movement, and mantra to awaken the energy at the base of the spine and raise it up through the chakras.", "10-30 minutes", "kundalini-meditation.jpg", "Kundalini Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/kundalini-meditation.jpg" },
                    { 16, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3741), "Involves sitting in silence and observing the mind without judgment.", "10-60 minutes", "silent-meditation.jpeg", "Silent Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/silent-meditation.jpeg" },
                    { 17, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3744), "Involves focusing on a specific object or sound to maintain concentration and develop awareness.", "10-30 minutes", "open-monitoring-meditation.jpg", "Open Monitoring Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/open-monitoring-meditation.jpg" },
                    { 18, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3860), "Involves focusing on a specific object or sound to maintain concentration and develop awareness.", "10-30 minutes", "focused-attention-meditation.jpg", "Focused Attention Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/focused-attention-meditation.jpg" },
                    { 19, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3865), "Involves cultivating feelings of loving-kindness and compassion towards oneself and others.", "10-30 minutes", "metta-meditation.jpg", "Metta Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/metta-meditation.jpg" },
                    { 20, new DateTime(2023, 12, 13, 4, 10, 33, 43, DateTimeKind.Local).AddTicks(3868), "Involves focusing on the sensations in the body to develop awareness and relaxation.", "10-30 minutes", "body-awareness-meditation.jpg", "Body Awareness Meditation", "https://medi-coursework.s3.eu-west-2.amazonaws.com/body-awareness-meditation.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "AudioKey", "MeditationId", "S3UrlAudio", "SessionName" },
                values: new object[,]
                {
                    { 1, "Dreamy Breeze.mp3", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Dreamy+Breeze.mp3", "Dreamy Breeze" },
                    { 2, "Peace of the Lake.mp3", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Peace+of+the+Lake.mp3", "Peace of the Lake" },
                    { 3, "Silent Symphony.mp3", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Silent+Symphony.mp3", "Silent Symphony" },
                    { 4, "Calm Waters.mp3", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Calm+Waters.mp3", "Calm Waters" },
                    { 5, "Deep Equilibrium.mp3", 1, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Deep+Equilibrium.mp3", "Deep Equilibrium" },
                    { 6, "Transcendental Tranquility.mp3", 2, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Transcendental+Tranquility.mp3", "Transcendental Tranquility" },
                    { 7, "Path to Inner Peace.mp3", 2, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Path+to+Inner+Peace.mp3", "Path to Inner Peace" },
                    { 8, "Conscious Immersion.mp3", 2, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Conscious+Immersion.mp3", "Conscious Immersion" },
                    { 9, "Kindness Unfolding Practice.mp3", 3, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Kindness+Unfolding+Practice.mp3", "Kindness Unfolding Practice" },
                    { 10, "Radiant Love Meditation.mp3", 3, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Radiant+Love+Meditation.mp3", "Radiant Love Meditation" },
                    { 11, "Meditation of Compassionate Hearts.mp3", 3, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Meditation+of+Compassionate+Hearts.mp3", "Meditation of Compassionate Hearts" },
                    { 12, "Mindful Body Unveiling.mp3", 4, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Mindful+Body+Unveiling.mp3", "Mindful Body Unveiling" },
                    { 13, "Somatic Awareness Practice.mp3", 4, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Somatic+Awareness+Practice.mp3", "Somatic Awareness Practice" },
                    { 14, "Sensory Body Exploration.mp3", 4, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Sensory+Body+Exploration.mp3", "Sensory Body Exploration" },
                    { 15, "Insightful Mindfulness Practice.mp3", 5, "https://medi-coursework.s3.eu-west-2.amazonaws.com/Insightful+Mindfulness+Practice.mp3", "Insightful Mindfulness Practice" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedSessions_SessionId",
                table: "CompletedSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedSessions_UserId",
                table: "CompletedSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MeditationId",
                table: "Sessions",
                column: "MeditationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedSessions");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Meditations");
        }
    }
}
