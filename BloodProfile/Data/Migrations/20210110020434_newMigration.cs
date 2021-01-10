using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodProfile.Data.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ExamDate = table.Column<DateTime>(nullable: false),
                    ResultsDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Hemoglobin = table.Column<double>(nullable: false),
                    Hematocrit = table.Column<double>(nullable: false),
                    WhiteBloodCellCount = table.Column<double>(nullable: false),
                    RedBloodCellCount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
