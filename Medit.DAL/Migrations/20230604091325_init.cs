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
                name: "SessionGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    S3UrlFoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionGroups", x => x.Id);
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
                    SessionGroupId = table.Column<int>(type: "int", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S3UrlAudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_SessionGroups_SessionGroupId",
                        column: x => x.SessionGroupId,
                        principalTable: "SessionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedSessions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SessionСounter = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedSessions", x => new { x.UserId, x.SessionId });
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
                table: "SessionGroups",
                columns: new[] { "Id", "CreationDate", "GroupName", "S3UrlFoto" },
                values: new object[] { 1, new DateTime(2023, 6, 4, 12, 13, 25, 27, DateTimeKind.Local).AddTicks(2383), "Mindfulness for Beginners", "foto1" });

            migrationBuilder.InsertData(
                table: "SessionGroups",
                columns: new[] { "Id", "CreationDate", "GroupName", "S3UrlFoto" },
                values: new object[] { 2, new DateTime(2023, 6, 4, 12, 13, 25, 29, DateTimeKind.Local).AddTicks(2090), "Mindfulness Tools", "foto2" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Duration", "S3UrlAudio", "SessionGroupId", "SessionName" },
                values: new object[,]
                {
                    { 1, null, null, 1, "The Big Idea" },
                    { 2, null, null, 1, "Homebase" },
                    { 3, null, null, 1, "Pop Out of Your Thoughts" },
                    { 4, null, null, 1, "Inner Smoothness" },
                    { 5, null, null, 1, "Take the Power Back" },
                    { 6, null, null, 2, "Introduction" },
                    { 7, null, null, 2, "Dealing with Change and Uncertainty" },
                    { 8, null, null, 2, "Combating Loneliness" },
                    { 9, null, null, 2, "Getting Through a Hectic Day" },
                    { 10, null, null, 2, "Dealing with Negativity in the World" },
                    { 11, null, null, 2, "Easing Holiday Stress" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedSessions_SessionId",
                table: "CompletedSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SessionGroupId",
                table: "Sessions",
                column: "SessionGroupId");
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
                name: "SessionGroups");
        }
    }
}
