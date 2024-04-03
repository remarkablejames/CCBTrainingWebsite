using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingWebsite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("ada6a04b-9bc0-472e-a385-921f6fcc17d3"), "C# Fundamentals Training", new DateTime(2024, 4, 8, 17, 26, 8, 699, DateTimeKind.Utc).AddTicks(3560), "C# Fundamentals", new DateTime(2024, 4, 3, 17, 26, 8, 699, DateTimeKind.Utc).AddTicks(3560) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainings");
        }
    }
}
