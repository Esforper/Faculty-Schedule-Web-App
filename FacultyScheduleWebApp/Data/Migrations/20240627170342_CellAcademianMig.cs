using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultyScheduleWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CellAcademianMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkspaceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademianFaculty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademianLessonCount = table.Column<int>(type: "int", nullable: false),
                    LessonCodesSerialized = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvaibleDatesSerialized = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateCells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonAcademian = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonClass = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellRow = table.Column<int>(type: "int", nullable: false),
                    CellColumn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateCells", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Academians");

            migrationBuilder.DropTable(
                name: "DateCells");
        }
    }
}
