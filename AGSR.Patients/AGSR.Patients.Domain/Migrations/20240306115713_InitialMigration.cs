using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGSR.Patients.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GivenNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GivenNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GivenNameName",
                columns: table => new
                {
                    GivenNamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GivenNameName", x => new { x.GivenNamesId, x.NameId });
                    table.ForeignKey(
                        name: "FK_GivenNameName_GivenNames_GivenNamesId",
                        column: x => x.GivenNamesId,
                        principalTable: "GivenNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GivenNameName_Names_NameId",
                        column: x => x.NameId,
                        principalTable: "Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Names_Id",
                        column: x => x.Id,
                        principalTable: "Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GivenNameName_NameId",
                table: "GivenNameName",
                column: "NameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GivenNameName");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "GivenNames");

            migrationBuilder.DropTable(
                name: "Names");
        }
    }
}
