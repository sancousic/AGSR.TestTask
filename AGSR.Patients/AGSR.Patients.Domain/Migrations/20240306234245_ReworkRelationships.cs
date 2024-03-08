using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGSR.Patients.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ReworkRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Names_Id",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "GivenNameName");

            migrationBuilder.AddColumn<Guid>(
                name: "NameId",
                table: "GivenNames",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GivenNames_NameId",
                table: "GivenNames",
                column: "NameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GivenNames_Names_NameId",
                table: "GivenNames",
                column: "NameId",
                principalTable: "Names",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Names_Patients_Id",
                table: "Names",
                column: "Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GivenNames_Names_NameId",
                table: "GivenNames");

            migrationBuilder.DropForeignKey(
                name: "FK_Names_Patients_Id",
                table: "Names");

            migrationBuilder.DropIndex(
                name: "IX_GivenNames_NameId",
                table: "GivenNames");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "GivenNames");

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

            migrationBuilder.CreateIndex(
                name: "IX_GivenNameName_NameId",
                table: "GivenNameName",
                column: "NameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Names_Id",
                table: "Patients",
                column: "Id",
                principalTable: "Names",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
